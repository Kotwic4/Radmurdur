using UnityEngine;
using UnityEngine.UI;

public class Configuration : MonoBehaviour
{
    public GameObject generator;
    private InputField amountInput;
    private InputField rateInput;
    private Button saveButton;
    private Button cancelButton;

    void Start()
    {
        amountInput = transform.Find("Amount").GetComponent<InputField>();
        rateInput = transform.Find("Rate").GetComponent<InputField>();
        saveButton = transform.Find("Save").GetComponent<Button>();
        cancelButton = transform.Find("Cancel").GetComponent<Button>();

        saveButton.onClick.AddListener(OnSave);
        cancelButton.onClick.AddListener(OnCancel);

        amountInput.text = generator.GetComponent<Generation>().prefabsToGenerate.ToString();
        rateInput.text = generator.GetComponent<Generation>().generationRate.ToString();
    }

    void OnSave()
    {
        generator.GetComponent<Generation>().prefabsToGenerate = int.Parse(amountInput.text.ToString());
        generator.GetComponent<Generation>().generationRate = float.Parse(rateInput.text.ToString());

        OnCancel();
    }

    void OnCancel()
    {
        Destroy(gameObject);
    }
}
