using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OwlController : MonoBehaviour
{
    public AudioController audioController;
    public GameController GameController;
    private string hint1;
    private string hint2;
    private string hint3;
    public GameObject textBoxPrefab;
    private bool collider_switch;
    public Animator owlAnim;
    private string current_hint = "placeholder";

    // Start is called before the first frame update
    void Start()
    {
        collider_switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Owl Clicked");
        if (collider_switch == false)
        {
            return;
        }
        collider_switch = false;
        audioController.OwlHoot.PlayOneShot(audioController.OwlHoot.clip);
        owlAnim.SetTrigger("OwlClicked");
        // Getting the hint
        LevelDefinition level = GameController.GetCurrentLevel();
        hint1 = level.instructions[0].hint;
        hint2 = level.instructions[1].hint;
        hint3 = level.instructions[2].hint;

        // Get progress from game controller and pick the appropriate hint


        // Logic: pick the highest hint that the player hasn't correctly completed
        

        // Instantiating the text box for the hint
        // X = 3.78, Y = 3.86, Z = 18.4
        GameObject instantiatedOwlText = Instantiate(textBoxPrefab, new Vector3(3.78f, 3.86f, 18.47f), Quaternion.identity);
        instantiatedOwlText.GetComponentInChildren<TextMeshProUGUI>().SetText(current_hint);
        Object.Destroy(instantiatedOwlText, 4.0f);
        StartCoroutine(OwlLag());

    }

    private IEnumerator OwlLag()
    {
        
        yield return new WaitForSeconds(5);
        collider_switch = true;
    }

}
