using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceProgress : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] TextMeshProUGUI levelText;

    public void UpdateExperience(int currentExp, int targetExp)
    {
        slider.maxValue = targetExp;
        slider.value = currentExp;
    }

    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL:" + level;
    }
}
