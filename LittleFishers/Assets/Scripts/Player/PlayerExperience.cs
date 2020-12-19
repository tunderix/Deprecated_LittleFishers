using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerExperience
{
    [SerializeField]
    private int _experience;
    [SerializeField]
    private int _level;
    private event OnExperienceAmountChanged _onExperienceAmountChanged;
    private event OnLevelChanged _onLevelChanged;
    private static int _experienceNeededToLevelUp = 20;
    public PlayerExperience(int startExperience)
    {
        this._experience = startExperience;
    }

    public int ExperienceValue
    {
        get
        {
            return this._experience;
        }
        set
        {
            int oldValue = this._experience;

            // Guard negative values
            int newValue = value < 0 ? 0 : value;

            this._experience = newValue;

            //Check for change
            if (this._experience != oldValue)
            {
                this.UpdateLevel();
                if (_onExperienceAmountChanged != null)
                    _onExperienceAmountChanged(ExperienceTrackValueFor(oldValue), ExperienceTrackValueFor(_experience));
            }
        }
    }

    public void SubscribeToExperienceChange(OnExperienceAmountChanged onExperienceAmountChanged)
    {
        this._onExperienceAmountChanged = onExperienceAmountChanged;
    }

    public void SubscribeToLevelChange(OnLevelChanged onLevelChanged)
    {
        this._onLevelChanged = onLevelChanged;
    }

    private float ExperienceTrackValueFor(int experienceAmount)
    {
        int expAfterLevelUp = experienceAmount - ((_level - 1) * _experienceNeededToLevelUp);
        return ((float)expAfterLevelUp) / ((float)_experienceNeededToLevelUp);
    }

    // Add experience and return bool for level up
    public bool Add(int experienceValue)
    {

        Debug.Log("Adding Experience: " + experienceValue);
        // Store level before changes
        int levelBefore = _level;

        // Add experience and calculate level
        this.ExperienceValue = this._experience + experienceValue;

        // Level up
        if (LevelUp(levelBefore, _level))
        {
            _onLevelChanged(levelBefore, _level);
            return true;
        }
        return false;
    }

    private bool LevelUp(int before, int after)
    {
        return before < after;
    }

    public int PlayerLevel
    {
        get
        {
            return _level;
        }
    }

    private void UpdateLevel()
    {
        // Calculate Level to be set
        int newLevel = this._experience / _experienceNeededToLevelUp;
        newLevel += 1;
        // guard going under 1
        if (newLevel < 1) newLevel = 1;

        this._level = newLevel;
    }
}
