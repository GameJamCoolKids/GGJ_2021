/*
 * Logic for checking whether ingredient is correct or not
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBase : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IngredientController ingredientController = collision.gameObject.GetComponent<IngredientController>();
        if (ingredientController.ingredient == Enums.Ingredient.BadEgg)
        {

        }
    }
}
