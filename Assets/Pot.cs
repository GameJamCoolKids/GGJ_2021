using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something went in");
    }

}
