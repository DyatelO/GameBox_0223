using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;
    [SerializeField] private ExperienceProgress experienceProgress;
    public int LevelUp => level * 1000;

    private void Start()
    {
        experienceProgress.UpdateExperience(experience, LevelUp);
        experienceProgress.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceProgress.UpdateExperience(experience, LevelUp);
    }

    public void CheckLevelUp()
    {
        if (experience >= LevelUp)
        {
            experience -= LevelUp;
            level++;
            experienceProgress.SetLevelText(level);
        }
    }
}
