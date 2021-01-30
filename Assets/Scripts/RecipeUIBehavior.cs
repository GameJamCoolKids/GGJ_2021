using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeUIBehavior : MonoBehaviour


    
{
    public GameObject RecipeUI;
    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        // Get the instruction from the GameController




        // Toggle the RecipeUI on/off based on tab keyboard press
        if (Input.GetKeyDown("tab"))
        {
            RecipeUI.SetActive(!RecipeUI.activeInHierarchy);
        }


    }

    private void OnMouseDown()
    {
        // Toggle the RecipeUI on/off based on mouse click
        RecipeUI.SetActive(!RecipeUI.activeInHierarchy);


    }
}
