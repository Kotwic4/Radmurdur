import argparse
import csv
from pathlib import Path
from typing import List, NamedTuple

from mido import MidiFile, tick2second, MidiTrack, bpm2tempo, MetaMessage


class Beat(NamedTuple):
    note: int
    time: float


def template(class_name: str, quarter_duration: float, beats: List[Beat], drumrack):
    beats_code = f",\n{' ' * 8}".join(f"new Beat(Note.{drumrack[b.note]}, {b.time})" for b in beats)
    return f"""
using LevelData;

public class {class_name} : IDrumsPattern
{{
    private static readonly Beat[] BeatsArray = {{
        {beats_code}
    }};
    public double QuarterDuration {{ get {{ return {quarter_duration}; }} }}
    public Beat[] Beats {{ get {{ return BeatsArray; }} }}
}}
"""


def main(args):
    drumrack = read_drumrack(args.drumrack)

    with MidiFile(file=args.midi_file) as mid:
        if mid.type != 0:
            raise Exception('Expected single track MIDI file')

        if len(mid.tracks) != 1:
            raise Exception('Expected single MIDI track')

        tempo = bpm2tempo(args.bpm)
        quarter_duration = tick2second(mid.ticks_per_beat, mid.ticks_per_beat, tempo)

        beats: List[Beat] = list(read_beats(mid, tempo))
        beats.sort(key=lambda b: (b.time, b.note))

    with args.output:
        args.output.write(template(args.class_name, quarter_duration, beats, drumrack))


def read_beats(mid, tempo):
    track: MidiTrack = mid.tracks[0]

    now = 0
    for msg in track:
        now += msg.time

        if not isinstance(msg, MetaMessage) and msg.type == 'note_on':
            yield Beat(note=msg.note,
                       time=tick2second(now, mid.ticks_per_beat, tempo))


def read_drumrack(drumrack_file):
    drumrack = {}
    with drumrack_file:
        reader = csv.DictReader(drumrack_file)
        for row in reader:
            drumrack[int(row['note'])] = row['sample']
    return drumrack


def read_args():
    p = argparse.ArgumentParser(description='MIDI to Level Class Converter')
    p.add_argument('midi_file', metavar='MIDI', type=argparse.FileType('rb'),
                   help='Input MIDI file')
    p.add_argument('-c', '--class', dest='class_name', metavar='CLASS_NAME',
                   help='Level class name, defaults to MIDI file name without extension')
    p.add_argument('-d', '--drumrack', metavar='RACK', type=argparse.FileType('r'),
                   help='Drum rack file, defaults to a file named same as class next to MIDI file')
    p.add_argument('-o', '--output', metavar='OUTPUT', type=argparse.FileType('w', encoding='UTF-8'),
                   help='Output C# class file path, defaults to a file named same as class next to MIDI file')
    p.add_argument('--bpm', metavar='N', default=120.0, type=float,
                   help='Beats per minute, defaults to 120')

    args = p.parse_args()

    if not args.class_name:
        args.class_name = Path(args.midi_file.name).stem

    if not args.output:
        args.output = Path(args.midi_file.name) \
            .with_name(args.class_name) \
            .with_suffix('.cs') \
            .resolve() \
            .open('w', encoding='UTF-8')

    if not args.drumrack:
        args.drumrack = Path(args.midi_file.name) \
            .with_name(args.class_name) \
            .with_suffix('.drumrack') \
            .resolve() \
            .open('r', encoding='UTF-8')

    return args


if __name__ == '__main__':
    main(read_args())
