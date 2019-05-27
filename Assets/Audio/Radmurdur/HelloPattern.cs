
using LevelData;

public class HelloPattern : IDrumsPattern
{
    private static readonly Beat[] BeatsArray = {
        new Beat(Note.Kick1, 0.0),
        new Beat(Note.Snare1, 0.49019599999999997),
        new Beat(Note.Kick1, 1.2203837916666667),
        new Beat(Note.Snare1, 1.7105797916666667),
        new Beat(Note.Kick1, 2.2007757916666666),
        new Beat(Note.Snare1, 2.4458737916666666),
        new Beat(Note.Snare1, 3.426265791666667),
        new Beat(Note.Break1, 3.553921),
        new Beat(Note.Kick1, 3.9215679999999997),
        new Beat(Note.Snare1, 4.411764),
        new Beat(Note.Kick1, 5.141951791666666),
        new Beat(Note.Snare1, 5.632147791666666),
        new Beat(Note.Kick1, 6.12745),
        new Beat(Note.Snare1, 6.367441791666667),
        new Beat(Note.Snare1, 7.347833791666667),
        new Beat(Note.Break1, 7.475489)
    };
    public double QuarterDuration { get { return 0.49019599999999997; } }
    public double Duration { get { return 8.55; } }
    public double Bpm { get { return 122.4; } }
    public Beat[] Beats { get { return BeatsArray; } }
}
