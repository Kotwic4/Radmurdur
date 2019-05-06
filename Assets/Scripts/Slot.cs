using UnityEngine;

public class Slot : MonoBehaviour
{
    public Object prefab;

    // Use this for initialization
    private void Start()
    {
        Rigidbody parent = GetComponent<Rigidbody>();
		var obj = (GameObject) Instantiate(prefab, parent.position, parent.rotation);
		obj.transform.parent = gameObject.transform;
        obj.transform.localScale = new Vector3(10, 10, 10);
		obj.GetComponent<Rigidbody>().isKinematic = true;
    }
}