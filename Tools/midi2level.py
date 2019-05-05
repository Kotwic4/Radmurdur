import argparse
from collections import namedtuple
from pathlib import Path

from mido import MidiFile, tick2second, MidiTrack, bpm2tempo, MetaMessage

Trigger = namedtuple('Trigger', ['note', 'time'])


def main(args):
    for t in read_triggers(args.midi_file, args.bpm):
        print(t)


def read_triggers(midi_file, bpm):
    tempo = bpm2tempo(bpm)

    with MidiFile(file=midi_file) as mid:
        if mid.type != 0:
            raise Exception('Expected single track MIDI file')

        if len(mid.tracks) != 1:
            raise Exception('Expected single MIDI track')

        track: MidiTrack = mid.tracks[0]

        now = 0
        for msg in track:
            now += msg.time

            if not isinstance(msg, MetaMessage):
                yield Trigger(note=msg.note,
                              time=tick2second(now, mid.ticks_per_beat, tempo))


def read_args():
    p = argparse.ArgumentParser(description='MIDI to Trigger Array Converter')
    p.add_argument('midi_file', metavar='MIDI', type=argparse.FileType('rb'),
                   help='Input MIDI file')
    p.add_argument('-c', '--class', dest='class_name', metavar='CLASS_NAME',
                   help='Level class name, defaults to MIDI file name without extension')
    p.add_argument('-o', '--output', metavar='OUTPUT', type=argparse.FileType('w', encoding='UTF-8'),
                   help='Output C# class file path, defaults to a file named same as class next to MIDI file')
    p.add_argument('--bpm', metavar='N', default=120,
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

    return args


if __name__ == '__main__':
    main(read_args())
