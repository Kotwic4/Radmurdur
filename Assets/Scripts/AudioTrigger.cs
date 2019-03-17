using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    private AudioSource audioData;
    private BallType.BallTypeEnum myType;

    private void Start()
    {
        myType = GetComponent<BallType>().type;
        audioData = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            BallType.BallTypeEnum ballType = collisionGameObject.GetComponent<BallType>().type;
            if(ballType == myType)
            {
                 audioData.Play();
            }
        }
    }
}
