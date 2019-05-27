using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            var ballType = collisionGameObject.GetComponent<BallType>().type;
            Debug.Log("Enter " + ballType.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collisionGameObject = other.gameObject;
        if (collisionGameObject.CompareTag("Ball"))
        {
            var ballType = collisionGameObject.GetComponent<BallType>().type;
            Debug.Log("Exit " + ballType.ToString());
        }
    }
}
