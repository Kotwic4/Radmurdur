using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

    public Object prefab;

    public float generationRate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Generate", 0, generationRate);
	}

    void Generate()
    {
        Rigidbody parent = GetComponent<Rigidbody>();
        Instantiate(prefab, parent.position, parent.rotation);
    }
}
