using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private int _maxWoodcuttingLevel;
    [SerializeField] private int _maxStonecuttingLevel;
    [SerializeField] private int _maxHealthLevel;
    [SerializeField] private int _maxDamageLevel;

    public float WoodcuttingSpeed { get; private set; }
    public float StonecuttingSpeed { get; private set; }
    public int HealthPoints { get; private set; }
    public int Damage { get; private set; }

    public int WoodcuttingLevel { get; private set; }
    public int StonecuttingLevel { get; private set; }
    public int HealthLevel { get; private set; }
    public int DamageLevel { get; private set; }
    public int MaxWoodcuttingLevel { get => _maxWoodcuttingLevel; }
    public int MaxStonecuttingLevel { get => _maxStonecuttingLevel; }
    public int MaxHealthLevel { get => _maxHealthLevel; }
    public int MaxDamageLevel { get => _maxDamageLevel; }

    private const string WoodcuttingSpeedKey = "WoodcuttingSpeed";
    private const string StonecuttingSpeedKey = "StonecuttingSpeed";
    private const string HealthPointsKey = "HealthPoints";
    private const string DamageKey = "Damage";

    private const string WoodcuttingLevelKey = "WoodcuttingLevel";
    private const string StonecuttingLevelKey = "StonecuttingLevel";
    private const string HealthLevelKey = "HealthLevel";
    private const string DamageLevelKey = "DamageLevel";

    public delegate void PlayerAbilitiesUpgradeDelegate();
    public static event PlayerAbilitiesUpgradeDelegate PlayerAbilitiesUpgrade;

    public void Awake()
    {
        WoodcuttingSpeed = PlayerPrefs.GetFloat(WoodcuttingSpeedKey, 10f);
        StonecuttingSpeed = PlayerPrefs.GetFloat(StonecuttingSpeedKey, 10f);
        HealthPoints = PlayerPrefs.GetInt(HealthPointsKey, 10);
        Damage = PlayerPrefs.GetInt(DamageKey, 10);

        WoodcuttingLevel = PlayerPrefs.GetInt(WoodcuttingLevelKey, 1);
        StonecuttingLevel = PlayerPrefs.GetInt(StonecuttingLevelKey, 1);
        HealthLevel = PlayerPrefs.GetInt(HealthLevelKey, 1);
        DamageLevel = PlayerPrefs.GetInt(DamageLevelKey, 1);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(WoodcuttingSpeedKey, WoodcuttingSpeed);
        PlayerPrefs.SetFloat(StonecuttingSpeedKey, StonecuttingSpeed);
        PlayerPrefs.SetInt(HealthPointsKey, HealthPoints);
        PlayerPrefs.SetInt(DamageKey, Damage);

        PlayerPrefs.SetInt(WoodcuttingLevelKey, WoodcuttingLevel);
        PlayerPrefs.SetInt(StonecuttingLevelKey, StonecuttingLevel);
        PlayerPrefs.SetInt(HealthLevelKey, HealthLevel);
        PlayerPrefs.SetInt(DamageLevelKey, DamageLevel);

        PlayerPrefs.Save();
    }

    public void UpgradeAbility(string ability)
    {
        switch (ability)
        {
            case "Woodcutting":
                WoodcuttingSpeed += 0.5f;
                WoodcuttingLevel++;
                break;
            case "Stonecutting":
                StonecuttingSpeed += 0.5f;
                StonecuttingLevel++;
                break;
            case "Health":
                HealthPoints += 20;
                HealthLevel++;
                break;
            case "Damage":
                Damage += 5;
                DamageLevel++;
                break;
        }
        Save();
    }
}
