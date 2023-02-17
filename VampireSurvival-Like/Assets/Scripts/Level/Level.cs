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
    private List<UpgradeData> selectedUpgrades;
    [SerializeField] private List<UpgradeData> acquiredUpgrades;

    private WeaponController weaponController;

    public int LevelUp => level * 1000;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

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

    //Не забыть про стартовый выбор оружия.
    public void Upgrade(int sekectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[sekectedUpgradeId];

        if(acquiredUpgrades == null)
        {
            acquiredUpgrades = new List<UpgradeData>();
        }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                break;            
            case UpgradeType.ItemUpgrade:
                break;            
            case UpgradeType.WeaponUnlock:
                weaponController.AddWeapon(upgradeData.weaponData);
                break;            
            case UpgradeType.ItemUnlock:
                break;

        }

        acquiredUpgrades.Add(upgradeData);
        upgradeDatasList.Remove(upgradeData);
    }

    private void NextLevel()
    {
        if(selectedUpgrades == null)
        {
            selectedUpgrades = new List<UpgradeData>();
        }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgradesList(3));

        upgradePanelController.OpeneMenu(selectedUpgrades);
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
