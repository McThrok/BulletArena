using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelScriptableObject", order = 1)]
public class LevelData : ScriptableObject
{
    public float SpawnTime;
    public int EnemyCount;
    public string Comment;
}