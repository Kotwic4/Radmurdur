using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public int levels;
    public Object prefab;

    void Start() {
        Rigidbody parent = GetComponent<Rigidbody>();

        for (int i = 0; i < levels; i++) {
            var obj = (GameObject) Instantiate(prefab, parent.position, parent.rotation);
            var levelNumber = i+1;
            
            obj.transform.SetParent(gameObject.transform.GetChild(0).gameObject.transform, false);
            
            obj.transform.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(levelNumber));
            obj.transform.Find("Text").GetComponent<Text>().text = "Level " + (i+1).ToString(); 
            
        }
    }

    public void OnButtonClick(int id) {
        Debug.Log("Level: " + id);
    }
}