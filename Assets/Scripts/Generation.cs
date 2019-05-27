using UnityEngine;

public class Generation : MonoBehaviour
{
    public Object prefab;

    public int prefabsToGenerate = 0;

    public float generationRate = .8f;

    public Vector3 initialSpeed = new Vector3(0f, 0f, 0f);

    public bool useGravity = true;

    public bool isGenerating = false;

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        if (prefabsToGenerate > 0 && !isGenerating)
        {
            Generate();
        }
    }

    private void Generate()
    {
        if (prefabsToGenerate <= 0)
        {
            isGenerating = false;
            return;
        }

        isGenerating = true;
        GenerateInstantiate();
        prefabsToGenerate -= 1;
        Invoke("Generate", generationRate);
    }

    public void GenerateInstantiate(Vector3 initialSpeed, bool useGravity)
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        GameObject obj = (GameObject) Instantiate(prefab, parent.position, parent.rotation);
        obj.GetComponent<Rigidbody>().velocity = initialSpeed;
        obj.GetComponent<Rigidbody>().useGravity = useGravity;
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
}
