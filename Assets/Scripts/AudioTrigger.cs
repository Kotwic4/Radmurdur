using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource audioData;
    private Note myType;

    private void Start()
    {
        myType = GetComponent<BallType>().type;
        audioData = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            var ballType = collisionGameObject.GetComponent<BallType>().type;
            if (ballType == myType)
            {
                audioData.Play();
            }
        }
    }
}
