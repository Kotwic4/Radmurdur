using LevelData;
using UnityEngine;

public class Level2 : MonoBehaviour, IDrumsPattern
{
    private static readonly Beat[] BeatsArray = {
        new Beat(Note.Kick1, 0.0),
        new Beat(Note.Kick1, 1.0),
        new Beat(Note.Kick2, 1.0),
        new Beat(Note.Kick1, 2.0),
        new Beat(Note.Kick1, 3.0),
        new Beat(Note.Kick2, 3.0),
    };
    public double QuarterDuration { get { return 0.49019599999999997; } }
    public double Duration { get { return 8.55; } }
    public double Bpm { get { return 122.4; } }
    public Beat[] Beats { get { return BeatsArray; } }
}
