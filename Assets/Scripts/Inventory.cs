using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Object slotPrefab;
    public Object[] prefabs;
    private GameObject[] objects;
    public int[] amounts;

    // Use this for initialization
    private void Start()
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        objects = new GameObject[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            var obj = (GameObject) Instantiate(slotPrefab, parent.position, parent.rotation);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Slot>().prefab = prefabs[i];
            obj.GetComponent<Slot>().amount = amounts[i];
            obj.GetComponent<Slot>().inventory = gameObject;

            objects[i] = obj;

            obj.transform.SetParent(gameObject.transform.GetChild(0).gameObject.transform, false);
        }
    }

    public void remove(Object prefab)
    {
        var index = System.Array.FindIndex(prefabs, p => p == prefab);
        var obj = objects[index];

        obj.GetComponent<Slot>().remove();
    }

    public void add(Object prefab)
    {
        var index = System.Array.FindIndex(prefabs, p => p == prefab);
        var obj = objects[index];

        obj.GetComponent<Slot>().add();
    }
}
