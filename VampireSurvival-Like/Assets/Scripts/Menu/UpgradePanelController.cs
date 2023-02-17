using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    private PauseController pauseController;

    private void Awake()
    {
        pauseController = GetComponent<PauseController>();
    }

    public void CloseMenu()
    {
        levelUpPanel.SetActive(false);
        pauseController.ContinueGame();
    }
    public void OpeneMenu()
    {
        pauseController.PauseGame();
        levelUpPanel.SetActive(true);
    }
}
