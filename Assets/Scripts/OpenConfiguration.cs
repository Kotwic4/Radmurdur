using UnityEngine;
using UnityEngine.UI;

public class OpenConfiguration : MonoBehaviour
{
    public bool enabled;
    public Object configuration;
    private Canvas canvas;
    private bool hover = false;
    private bool shown = false;
    private GameObject configurationGameObject;

    private void Start()
    {
        GameObject tempObject = GameObject.Find("Canvas");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            canvas = tempObject.GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
    }

    void Update()
    {
        if (enabled && hover && Input.GetMouseButtonDown(1) && configurationGameObject == null)
        {
            Rigidbody parent = GetComponent<Rigidbody>();
            configurationGameObject = (GameObject) Instantiate(configuration, parent.position, parent.rotation);
            configurationGameObject.GetComponent<Configuration>().generator = gameObject;

            configurationGameObject.transform.SetParent(canvas.transform, false);
            configurationGameObject.transform.position = gameObject.transform.position;
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
