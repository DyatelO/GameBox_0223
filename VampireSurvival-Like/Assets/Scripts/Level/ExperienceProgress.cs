using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceProgress : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateExperience(int currentExp, int targetExp)
    {
        slider.maxValue = targetExp;
        slider.value = currentExp;
    }
}
