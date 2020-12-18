using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField]
    private int strength;
    [SerializeField]
    private int experience;
    int defaultLevel;
    public PlayerStats(int defaultExperience, int defaultStrength)
    {
        strength = defaultStrength;
        experience = defaultExperience;
        defaultLevel = 1;
    }

    public int PlayerLevel
    {
        get
        {
            int level = defaultLevel;

            level = experience % 4;
            if (experience < 4) level = 1;

            return level;
        }
    }

    private int GetPlayerLevel(int newExperienceAmount)
    {
        int level = defaultLevel;

        level = newExperienceAmount % 4;
        if (newExperienceAmount < 4) level = 1;

        return level;
    }

    public void AddExperience(int amount)
    {
        int newAmount = this.experience + amount;

        if (PlayerLevel < GetPlayerLevel(newAmount))
        {
            Debug.Log("Ahop!");
            LevelUp();
        }

        this.experience = newAmount;
    }

    public void AddStrength()
    {
        this.strength += 1;
    }

    public void LevelUp()
    {
        AddStrength();
    }

    public int GetPlayerStrength()
    {
        return strength;
    }
}
