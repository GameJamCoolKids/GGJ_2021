/*
 * Defines an enemy type
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Instruction", menuName = "Instruction")]
public class InstructionDefinition : ScriptableObject
{
    public Enums.Ingredient correctIngredient;
    public string instruction;
}