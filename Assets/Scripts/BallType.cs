using UnityEngine;

public class BallType : MonoBehaviour
{
    public enum BallTypeEnum
    {
        Cymbal,
        Hat,
        Kick,
        Snare
    };

    public BallTypeEnum type;
}