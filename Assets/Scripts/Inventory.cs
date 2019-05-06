using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Object slotPrefab;
    public Object[] prefabs;
    public int[] amounts;

    // Use this for initialization
    private void Start()
    {
        Rigidbody parent = GetComponent<Rigidbody>();

        for (int i = 0; i < prefabs.Length; i++) {
            var obj = (GameObject) Instantiate(slotPrefab, parent.position, parent.rotation);
            obj.transform.parent = gameObject.transform;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Slot>().prefab = prefabs[i];
        }
    }
}