using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{

    public GameObject scoreBoard;

    public LinkedList<GameObject> arrayBreak1Generator = new LinkedList<GameObject>();
    public LinkedList<GameObject> arrayHorn1Generator = new LinkedList<GameObject>();
    public LinkedList<GameObject> arrayKick1Generator = new LinkedList<GameObject>();
    public LinkedList<GameObject> arrayKick2Generator = new LinkedList<GameObject>();
    public LinkedList<GameObject> arraySnare1Generator = new LinkedList<GameObject>();
    public LinkedList<GameObject> arraySnare2Generator = new LinkedList<GameObject>();

    private LinkedList<GameObject> GetTypeArray(Note noteType)
    {
        switch (noteType)
        {
            case Note.Break1:
                return arrayBreak1Generator;
            case Note.Horn1:
                return arrayHorn1Generator;
            case Note.Kick1:
                return arrayKick1Generator;
            case Note.Kick2:
                return arrayKick2Generator;
            case Note.Snare1:
                return arraySnare1Generator;
            case Note.Snare2:
                return arraySnare2Generator;
            default:
                return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            var ballType = collisionGameObject.GetComponent<BallType>().type;
            LinkedList<GameObject> array = GetTypeArray(ballType);
            array.AddLast(collisionGameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            var ballType = collisionGameObject.GetComponent<BallType>().type;
            LinkedList<GameObject> array = GetTypeArray(ballType);
            if(array.Count > 0)
            {
                GameObject gameObject = array.First.Value;
                Destroy(gameObject);
                array.RemoveFirst();
                scoreBoard.GetComponent<ScoreManager>().missSound();
            }
        }
    }

    public void playSound(Note note)
    {
        LinkedList<GameObject> array = GetTypeArray(note);
        if (array.Count > 0)
        {
            GameObject gameObject = array.First.Value;
            Destroy(gameObject);
            array.RemoveFirst();
            scoreBoard.GetComponent<ScoreManager>().goodSound();
        }
        else
        {
            scoreBoard.GetComponent<ScoreManager>().badSound();
        }
    }
}
