using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;
    [SerializeField] private ExperienceProgress experienceProgress;
    [SerializeField] private UpgradePanelController upgradePanelController;

    [SerializeField] private List<UpgradeData> upgradeDatasList;

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
            NextLevel();
        }
    }

    private void NextLevel()
    {
        upgradePanelController.OpeneMenu(GetUpgradesList(4));
        experience -= LevelUp;
        level++;
        experienceProgress.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgradesList(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count >  upgradeDatasList.Count)
        {
            count = upgradeDatasList.Count;
        }

        for (int i = 0; i < count; i++)
        {

            upgradeList.Add(upgradeDatasList[Random.Range(0, upgradeDatasList.Count)]);
        }

        return upgradeList;
    }
}
