using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeUIBehavior : MonoBehaviour
{
    public AudioController audioController;
    public GameObject RecipeUI;
    public GameController GameController;
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public TextMeshProUGUI instruction3;
    private string inst1;
    private string inst2;
    private string inst3;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        // Get the instruction from the GameController

        LevelDefinition level = GameController.GetCurrentLevel();
        inst1 = level.instructions[0].instruction;
        instruction1.SetText(inst1);
        inst2 = level.instructions[1].instruction;
        instruction2.SetText(inst2);
        inst3 =  level.instructions[2].instruction;
        instruction3.SetText(inst3);


        if(GameController.instruction1Solved == true)
        {
            instruction1.color = new Color32(34, 139, 34, 255);

        }

        if (GameController.instruction2Solved == true)
        {
            instruction2.color = new Color32(34, 139, 34, 255);

        }

        if (GameController.instruction3Solved == true)
        {
            instruction3.color = new Color32(34, 139, 34, 255);

        }

        if(GameController.correctAnswers >= 3 || GameController.incorrectAttempts >= 3)
        {
            instruction1.color = new Color32(0, 0, 0, 255);
            instruction2.color = new Color32(0, 0, 0, 255);
            instruction3.color = new Color32(0,0,0,255);


        }


        // Toggle the RecipeUI on/off based on tab keyboard press
        if (Input.GetKeyDown("tab"))
        {
            RecipeUI.SetActive(!RecipeUI.activeInHierarchy);
            audioController.BookFlip.PlayOneShot(audioController.BookFlip.clip);
        }


    }


    private void OnMouseDown()
    {
        audioController.BookFlip.PlayOneShot(audioController.BookFlip.clip);
        // Toggle the RecipeUI on/off based on mouse click
        RecipeUI.SetActive(!RecipeUI.activeInHierarchy);


    }
}
