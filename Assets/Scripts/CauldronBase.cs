﻿/*
 * Logic for checking whether ingredient is correct or not
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBase : MonoBehaviour
{
    public GameController gameController;
    public Animator CauldronAnim;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip);
        LevelDefinition level = gameController.GetCurrentLevel();
        Ingredient ingredientController = collision.gameObject.GetComponent<Ingredient>();
        if (ingredientController.ingredient == level.instructions[0].correctIngredient
            && gameController.IsInstruction1Solved() == false)
        {
            gameController.IncrementCorrectAnswers();
            gameController.SetInstruction1Solved();
            TriggerCorrectAnimationTriage();
            // trigger mark off of of book animation here
        }
        else if (ingredientController.ingredient == level.instructions[1].correctIngredient
                 && gameController.IsInstruction2Solved() == false)
        {
            gameController.IncrementCorrectAnswers();
            gameController.SetInstruction2Solved();
            TriggerCorrectAnimationTriage();
            // trigger mark off of of book animation here
        }
        else
        { // wrong answer
            gameController.IncrementIncorrectAttempts();
            if (gameController.GetIncorrectAttempts() >= gameController.ATTEMPTS_UNTIL_GAME_OVER)
            {
                // trigger the 'fail' animation HERE
                CauldronAnim.SetTrigger("Level_Lost");
                Debug.Log("Incorrect Ingredient Detected - 3 strikes and you're out!");
                // trigger mark off of of book
            }
            else
            {
                // trigger the 'incorret' animation HERE
                CauldronAnim.SetTrigger("Potion_Incorrect");
                Debug.Log("Incorrect Ingredient Detected");
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
            Debug.Log("Correct Ingredient Detected");
        }
        else
        {
            CauldronAnim.SetTrigger("Potion_Correct");
            Debug.Log("Correct Ingredient Detected");
        }
    }
}