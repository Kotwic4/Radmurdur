using UnityEngine;

public class Generation : MonoBehaviour
{
    public Object prefab;

    public int prefabsToGenerate;

    public float generationRate;

    // Use this for initialization
    private void Start()
    {
        Invoke("Generate", 0);
    }

    private void GenerateInstantiate()
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        Instantiate(prefab, parent.position, parent.rotation);
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