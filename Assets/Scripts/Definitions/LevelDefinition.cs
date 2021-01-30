using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Instruction", menuName = "Instruction")]
public class LevelDefinition : ScriptableObject
{
    public List<InstructionDefinition> instructions;
}
