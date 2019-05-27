
using LevelData;

public class HelloPattern : IDrumsPattern
{
    private static readonly Beat[] BeatsArray = {
        new Beat(Note.Kick1, 0.0),
        new Beat(Note.Snare1, 0.5),
        new Beat(Note.Kick1, 1.2447916666666665),
        new Beat(Note.Snare1, 1.7447916666666665),
        new Beat(Note.Kick1, 2.2447916666666665),
        new Beat(Note.Snare1, 2.4947916666666665),
        new Beat(Note.Horn1, 3.25),
        new Beat(Note.Snare1, 3.4947916666666665),
        new Beat(Note.Break1, 3.625),
        new Beat(Note.Kick1, 4.0),
        new Beat(Note.Snare1, 4.5),
        new Beat(Note.Kick1, 5.244791666666666),
        new Beat(Note.Snare1, 5.744791666666666),
        new Beat(Note.Kick1, 6.25),
        new Beat(Note.Snare1, 6.494791666666666),
        new Beat(Note.Horn1, 7.244791666666666),
        new Beat(Note.Snare1, 7.494791666666666),
        new Beat(Note.Break1, 7.625)
    };
    public double QuarterDuration { get { return 0.5; } }
    public Beat[] Beats { get { return BeatsArray; } }
}
