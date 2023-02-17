using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    private PauseController pauseController;

    private void Awake()
    {
        pauseController = GetComponent<PauseController>();
    }

    //Переписать под код, а не из инспектора.
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //mainMenuPanel.SetActive(true);
            switch (mainMenuPanel.activeInHierarchy)
            {
                case true:
                    CloseMenu();
                    break;                
                case false:
                    OpeneMenu();
                    break;
            }
        }
    }

    public void CloseMenu()
    {
        mainMenuPanel.SetActive(false);
        pauseController.ContinueGame();
    }
    public void OpeneMenu()
    {
        pauseController.PauseGame();
        mainMenuPanel.SetActive(true);
    }

}
