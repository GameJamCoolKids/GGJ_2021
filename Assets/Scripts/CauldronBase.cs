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
    public AudioSource plop;
    public AudioSource correct;
    public AudioSource incorrect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        plop.PlayOneShot(plop.clip);
        LevelDefinition level = gameController.GetCurrentLevel();
        Ingredient ingredientController = collision.gameObject.GetComponent<Ingredient>();
        if (ingredientController.ingredient == level.instructions[0].correctIngredient
            && gameController.IsInstruction1Solved() == false)
        {
            correct.PlayOneShot(correct.clip);
            gameController.IncrementCorrectAnswers();
            gameController.SetInstruction1Solved();
            TriggerCorrectAnimationTriage();
            // trigger mark off of of book animation here
        }
        else if (ingredientController.ingredient == level.instructions[1].correctIngredient
                 && gameController.IsInstruction2Solved() == false)
        {
            correct.PlayOneShot(correct.clip);
            gameController.IncrementCorrectAnswers();
            gameController.SetInstruction2Solved();
            TriggerCorrectAnimationTriage();
            // trigger mark off of of book animation here
        }
        else
        { // wrong answer
            incorrect.PlayOneShot(incorrect.clip);
            gameController.IncrementIncorrectAttempts();
            if (gameController.GetIncorrectAttempts() >= gameController.ATTEMPTS_UNTIL_GAME_OVER)
            {
                // trigger the 'fail' animation HERE
                CauldronAnim.SetTrigger("Level_Lost");
                // trigger mark off of of book
            }
            else
            {
                // trigger the 'incorret' animation HERE
                CauldronAnim.SetTrigger("Potion_Incorrect");
                // trigger mark off of of book
            }
        }
    }

    // decides whether to trigger a Level_Won or Potion_Correct animation
    private void TriggerCorrectAnimationTriage()
    {
        if (gameController.GetNumberOfCorrectAnswers() == 2)
        {
            CauldronAnim.SetTrigger("Level_Won");
        }
        else
        {
            CauldronAnim.SetTrigger("Potion_Correct");
        }
    }
}