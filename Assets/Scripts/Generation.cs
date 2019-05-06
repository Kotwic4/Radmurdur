using UnityEngine;

public class Generation : MonoBehaviour
{
    public Object prefab;

    public int prefabsToGenerate;

    public float generationRate;

    public Vector3 initialSpeed;

    public bool useGravity;

    // Use this for initialization
    private void Start()
    {
        Invoke("Generate", 0);
    }

    public void GenerateInstantiate(Vector3 initialSpeed, bool useGravity)
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        GameObject obj = (GameObject) Instantiate(prefab, parent.position, parent.rotation);
        obj.GetComponent<Rigidbody>().velocity = initialSpeed;
        obj.GetComponent<Rigidbody>().useGravity = useGravity;
        obj.transform.localScale = new Vector3(10, 10, 10);
    }

    public void GenerateInstantiate(Vector3 initialSpeed)
    {
        GenerateInstantiate(initialSpeed, useGravity);
    }

    public void GenerateInstantiate(bool useGravity)
    {
        GenerateInstantiate(initialSpeed, useGravity);
    }

    public void GenerateInstantiate()
    {
        GenerateInstantiate(initialSpeed, useGravity);
    }

    private void Generate()
    {
        if (prefabsToGenerate != 0)
        {
            GenerateInstantiate();
            prefabsToGenerate = Mathf.Max(prefabsToGenerate, 0) - 1;
            Invoke("Generate", generationRate);
        }
    }
}