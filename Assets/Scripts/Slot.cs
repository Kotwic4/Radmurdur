using UnityEngine;

public class Slot : MonoBehaviour
{
    public Object prefab;
    public int amount;

    public GameObject inventory;
    private GameObject obj;

    // Use this for initialization
    private void Start()
    {
        createPrefab();
        updateAmount();
    }

    public void remove()
    {
        amount--;
        createPrefab();
        updateAmount();
    }

    public void add()
    {
        amount++;
        updateAmount();
    }

    private void createPrefab()
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        obj = (GameObject) Instantiate(prefab, parent.position, parent.rotation);
        obj.transform.parent = gameObject.transform;

        if (obj.CompareTag("Wall"))
        {
            obj.transform.localScale = new Vector3(40, 10, 10);
        }
        else
        {
            obj.transform.localScale = new Vector3(10, 10, 10);
        }

        obj.GetComponent<Rigidbody>().isKinematic = true;

        obj.transform.SetParent(gameObject.transform, false);

        obj.GetComponent<DragAndDrop>().inventory = inventory;
        obj.GetComponent<DragAndDrop>().inInventory = true;
        obj.GetComponent<DragAndDrop>().prefab = prefab;
    }

    private void updateAmount()
    {
        var text = gameObject.transform.Find("Amount").gameObject;
        text.GetComponent<UnityEngine.UI.Text>().text = amount.ToString();

        if (amount > 0)
        {
            obj.GetComponent<DragAndDrop>().enabled = true;
        }
        else
        {
            obj.GetComponent<DragAndDrop>().enabled = false;
        }
    }
}
