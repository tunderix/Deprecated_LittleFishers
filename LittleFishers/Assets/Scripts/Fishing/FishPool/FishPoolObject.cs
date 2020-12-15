using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Fish Pool Object", menuName = "Fishing System/Fishpool")]
public class FishPoolObject : ScriptableObject
{
    public FishPoolDifficulty difficulty;
    [Range(0f, 1f)]
    public float fishProbability;
}
