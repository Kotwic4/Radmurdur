using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public bool success;
    public int stars;
    private Button playAgainButton;
    private Button menuButton;

    void Start() {
        playAgainButton = transform.Find("Again").GetComponent<Button>();
        menuButton = transform.Find("Menu").GetComponent<Button>();

        playAgainButton.onClick.AddListener(OnPlayAgain);
        menuButton.onClick.AddListener(OnGoMenu);

        if (stars == 0) {
            transform.Find("Star1").gameObject.SetActive(false);
            transform.Find("Star2").gameObject.SetActive(false);
            transform.Find("Star3").gameObject.SetActive(false);
        }
        else if (stars == 1) {
            transform.Find("Star2").gameObject.SetActive(false);
            transform.Find("Star3").gameObject.SetActive(false);
        }
        else if (stars == 2) {
            transform.Find("Star3").gameObject.SetActive(false);
        }

        if (success) {
            transform.Find("Result").GetComponent<UnityEngine.UI.Text>().text = "Level passed";
        }
        else {
            transform.Find("Result").GetComponent<UnityEngine.UI.Text>().text = "Level failed";
        }
    }

    void OnPlayAgain() {
        Debug.Log("OnPlayAgain");
    }

    void OnGoMenu() {
        Debug.Log("OnGoMenu");
    }
}