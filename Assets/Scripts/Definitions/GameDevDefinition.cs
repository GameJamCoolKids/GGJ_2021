/*
 * Defines an enemy type
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New GameDev", menuName = "GameDev")]
public class GameDevDefinition : ScriptableObject
{
    public Enums.GameDev gameDev;
    public Sprite portrait;
    public string role;
    public List<string> skills;
}