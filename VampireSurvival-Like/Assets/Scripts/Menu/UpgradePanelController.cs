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

    public void CloseMenu()
    {
        levelUpPanel.SetActive(false);
        pauseController.ContinueGame();
    }
    public void OpeneMenu(List<UpgradeData> upgradeDatas)
    {
        pauseController.PauseGame();
        levelUpPanel.SetActive(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]); 
        }
    }
}
