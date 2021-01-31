/*
 * Logic for checking whether ingredient is correct or not
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBase : MonoBehaviour
{
    public GameController gameController;
    public Animator CauldronAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelDefinition level = gameController.GetCurrentLevel();
        Ingredient ingredientController = collision.gameObject.GetComponent<Ingredient>();
        if (ingredientController.ingredient == level.instructions[0].correctIngredient)
        {
            gameController.IncrementCorrectAnswers();
            CauldronAnim.SetTrigger("Potion_Correct");
            Debug.Log("Correct Ingredient Detected");
            // trigger mark off of of book animation here
        }
        else if (ingredientController.ingredient == level.instructions[1].correctIngredient)
        {
            gameController.IncrementCorrectAnswers();
            CauldronAnim.SetTrigger("Potion_Correct");
            Debug.Log("Correct Ingredient Detected");
            // trigger mark off of of book animation here
        }
        else if (ingredientController.ingredient == level.instructions[2].correctIngredient)
        {
            gameController.IncrementCorrectAnswers();
            CauldronAnim.SetTrigger("Potion_Correct");
            Debug.Log("Correct Ingredient Detected");
            // trigger mark off of of book animation here
        }
        else
        { // wrong answer
            gameController.IncrementIncorrectAttempts();
            if (gameController.GetIncorrectAttempts() >= gameController.ATTEMPTS_UNTIL_GAME_OVER)
            {
                // trigger the 'incorrect' animation HERE
                CauldronAnim.SetTrigger("Potion_Incorrect");
                Debug.Log("Incorrect Ingredient Detected");
                // trigger mark off of of book
            }
            else
            {
                // trigger the 'dud' animation HERE
                CauldronAnim.SetTrigger("BacktoNormal");
                Debug.Log("Dud Ingredient Detected");
                // trigger mark off of of book
            }
        }
    }
}
