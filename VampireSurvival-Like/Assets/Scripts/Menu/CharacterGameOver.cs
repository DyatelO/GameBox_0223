using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] private GameObject weaponsMain;

    public void GameOver()
    {
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponsMain.SetActive(false);
    }
}
