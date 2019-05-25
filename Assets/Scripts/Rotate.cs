using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{
    public bool enabled;
    public float speed = 10;
    private bool hover = false;

    // Update is called once per frame
    void Update()
    {
        if (enabled && hover)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                gameObject.transform.Rotate(Vector3.forward * speed, Space.World);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                gameObject.transform.Rotate(-Vector3.forward * speed, Space.World);
            }
        }
    }

    void OnMouseOver()
    {
        hover = true;
    }

    void OnMouseExit()
    {
        hover = false;
    }
}
