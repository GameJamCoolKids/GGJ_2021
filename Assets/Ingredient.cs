using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{

    Vector3 worldPosition;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        transform.position = worldPosition;
    }
}
