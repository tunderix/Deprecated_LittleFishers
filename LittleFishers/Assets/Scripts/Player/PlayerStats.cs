using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField]
    private int strength;
    [SerializeField]
    private PlayerExperience experience;

    public PlayerStats(int defaultExperience, int defaultStrength)
    {
        strength = defaultStrength;
        experience = new PlayerExperience(defaultExperience);
    }

    public PlayerExperience Experience
    {
        get
        {
            return experience;
        }
    }

    public bool AddExperience(int amount)
    {
        bool levelUp = experience.Add(amount);
        if (levelUp) this.LevelUp();
        return levelUp;
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
