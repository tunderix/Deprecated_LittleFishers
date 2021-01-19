using UnityEngine;
using LittleFishers.LFInventory;

namespace LittleFishers.Fishing
{
    public class Fish
    {
        private FishSize _fishSize;
        private string _fishName;
        private string _fishSizeName;
        private string _description;
        private Sprite _icon;
        private int _goldValue;
        private int _strength;
        private int _weight;
        private int _experience;

        public Fish(InventoryItemTemplate_Fish template)
        {
            this._fishSizeName = template.ItemName;
            this._fishName = FishingHelper.RandomFishName;
            this._description = template.Description;
            this._icon = template.InventoryIcon;
            this._goldValue = randomInt(template.MinGoldValue, template.MaxGoldValue);
            this._strength = randomInt(template.MinStrength, template.MaxStrength);
            this._weight = randomInt(template.MinWeight, template.MaxWeight);
            this._experience = randomInt(template.MinExperienceGain, template.MaxExperienceGain);
        }

        private static int randomInt(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }


        public string FishName { get => this._fishName; }
        public string Description { get => this._description; }
        public FishSize Size { get => this._fishSize; }
        public int GoldValue { get => this._goldValue; }
        public Sprite FishIcon { get => this._icon; }
        public int Strength { get => this._strength; }
        public int Experience { get => this._experience; }
        public int Weight { get => this._weight; }

    }
}