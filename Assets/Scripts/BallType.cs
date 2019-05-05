using UnityEngine;

public class BallType : MonoBehaviour
{
    public enum BallTypeEnum
    {
        Break1,
        Horn1,
        Kick1,
        Kick2,
        Snare1,
        Snare2
    };

    public BallTypeEnum type;
}