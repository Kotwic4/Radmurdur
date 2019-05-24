
using LevelData;

public class HelloPattern : IDrumsPattern
{
    private static readonly Beat[] BeatsArray = {
        new Beat(Note.Kick1, 0.0),
        new Beat(Note.Kick1, 0.23999179166666668),
        new Beat(Note.Snare1, 0.49019599999999997),
        new Beat(Note.Snare1, 0.735294),
        new Beat(Note.Kick1, 1.2203837916666667),
        new Beat(Note.Kick1, 1.470588),
        new Beat(Note.Snare1, 1.7105797916666667),
        new Beat(Note.Snare1, 1.9556777916666666),
        new Beat(Note.Kick1, 2.2007757916666666),
        new Beat(Note.Snare1, 2.4458737916666666),
        new Beat(Note.Kick1, 2.45098),
        new Beat(Note.Snare1, 2.696078),
        new Beat(Note.Horn1, 3.186274),
        new Beat(Note.Snare1, 3.426265791666667),
        new Beat(Note.Horn1, 3.426265791666667),
        new Beat(Note.Break1, 3.553921),
        new Beat(Note.Snare1, 3.6049830833333334),
        new Beat(Note.Break1, 3.6203017083333333),
        new Beat(Note.Kick1, 3.9215679999999997),
        new Beat(Note.Kick1, 4.166666),
        new Beat(Note.Snare1, 4.411764),
        new Beat(Note.Snare1, 4.651755791666667),
        new Beat(Note.Kick1, 5.141951791666666),
        new Beat(Note.Kick1, 5.392156),
        new Beat(Note.Snare1, 5.632147791666666),
        new Beat(Note.Snare1, 5.877245791666667),
        new Beat(Note.Kick1, 6.12745),
        new Beat(Note.Kick1, 6.367441791666667),
        new Beat(Note.Snare1, 6.367441791666667),
        new Beat(Note.Snare1, 6.612539791666666),
        new Beat(Note.Horn1, 7.1027357916666665),
        new Beat(Note.Snare1, 7.347833791666667),
        new Beat(Note.Horn1, 7.347833791666667),
        new Beat(Note.Break1, 7.475489),
        new Beat(Note.Snare1, 7.526551083333334),
        new Beat(Note.Break1, 7.5418697083333335)
    };
    public double QuarterDuration { get { return 0.49019599999999997; } }
    public Beat[] Beats { get { return BeatsArray; } }
}
