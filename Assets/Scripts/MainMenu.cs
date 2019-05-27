using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button campaignModeButton;
    private Button sandboxModeButton;

    void Start()
    {
        campaignModeButton = transform.Find("CampaignMode").GetComponent<Button>();
        sandboxModeButton = transform.Find("SandboxMode").GetComponent<Button>();

        campaignModeButton.onClick.AddListener(OnStartCampaignMode);
        sandboxModeButton.onClick.AddListener(OnStartSandboxMode);
    }

    void OnStartCampaignMode()
    {
        Debug.Log("OnStartCampaignMode");
    }

    void OnStartSandboxMode()
    {
        Debug.Log("OnStartSandboxMode");
    }
}
