using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dev : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public float pushHeight = 7;
    public Animator DevAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        rb2D.AddForce(transform.up * pushHeight, ForceMode2D.Impulse);
        rb2D.AddForce(transform.right * Random.Range(-1.0f, 1.0f), ForceMode2D.Impulse);
        GetComponent<CapsuleCollider2D>().enabled = false;
        DevAnim.SetBool("OnClick", true);
    }
}
