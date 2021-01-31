using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlController : MonoBehaviour
{
    public AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Owl Clicked");
        audioController.OwlHoot.PlayOneShot(audioController.OwlHoot.clip);
    }
}
