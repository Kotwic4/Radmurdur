using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BallType))]
public class AudioTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var collisionGameObject = collision.gameObject;
        if (!collisionGameObject.CompareTag("Ball")) return;
        
        var ballType = collisionGameObject.GetComponent<BallType>().type;
        var myType = GetComponent<BallType>().type;
        if (ballType != myType) return;
        
        GetComponent<AudioSource>().Play();
    }
}
