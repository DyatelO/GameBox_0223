using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    private PauseController pauseController;

    [SerializeField] private List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        pauseController = GetComponent<PauseController>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void CloseMenu()
    {
        HideButtons();

        levelUpPanel.SetActive(false);
        pauseController.ContinueGame();
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

    public void OpeneMenu(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseController.PauseGame();
        levelUpPanel.SetActive(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]); 
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID )
    {
        FindObjectOfType<Level>().Upgrade(pressedButtonID);
        CloseMenu();
    }
}
