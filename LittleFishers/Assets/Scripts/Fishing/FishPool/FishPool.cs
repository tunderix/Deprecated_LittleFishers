using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.Fishing
{
    public class FishPool : MonoBehaviour
    {
        [SerializeField]
        private FishPoolObject fishPoolObject;

        [SerializeField]
        private List<FishSize> possibleFishSizes;

        [SerializeField]
        private int recommendedMinimumLevel;

        public int ExperiencePenaltyModifier(int playerLevel)
        {
            int diff = playerLevel - recommendedMinimumLevel;
            return diff;
        }

        public FishSize RandomFishSize
        {
            get
            {
                return possibleFishSizes[UnityEngine.Random.Range(0, possibleFishSizes.Count)];
            }
        }
    }
}
