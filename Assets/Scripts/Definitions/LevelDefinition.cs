using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class LevelDefinition : ScriptableObject
{
    public List<Instruction> instructions;

    [System.Serializable]
    public class Instruction
    {
        public string instruction;
        public string hint;
        public Enums.Ingredient correctIngredient;
    }

}
