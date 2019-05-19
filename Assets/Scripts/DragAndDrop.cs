using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {
    public bool enabled;
    public bool inInventory;
    public GameObject inventory;

    public Object prefab;

    Vector3 dist;
    float posX;
    float posY;


    void OnMouseDown() {
        if (enabled) {
            dist = Camera.main.WorldToScreenPoint(transform.position);
            posX = Input.mousePosition.x - dist.x;
            posY = Input.mousePosition.y - dist.y;
        }
    }

    void OnMouseDrag() {
    
        if (enabled) {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);  

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
        }
    }
    
    void OnMouseUp() {
        if (enabled) { 
            RectTransform invPanel = inventory.transform as RectTransform;
            
            if (inInventory) {
                if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)) {
                    inInventory = false;
                    inventory.GetComponent<Inventory>().remove(prefab);
                    adjustPrefabToPlay();
                }
                else {
                    transform.localPosition = Vector3.zero;
                }
            }
            else if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)) {
                inventory.GetComponent<Inventory>().add(prefab);
                Destroy(gameObject);
            }
        }
    }

    private void adjustPrefabToPlay() {
        if (gameObject.CompareTag("Ball")) {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}