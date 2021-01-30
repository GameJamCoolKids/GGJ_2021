using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelDefinition : ScriptableObject
{
    public List<InstructionDefinition> instructions;
}
