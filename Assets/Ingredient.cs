﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Ingredient : MonoBehaviour
{
    public Enums.Ingredient ingredient;
    public Rigidbody2D rigidBody2D;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = this.gameObject.transform.position;
        originalRotation = this.gameObject.transform.localRotation;
    }

    void OnMouseDown() {
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        CloneGameObject();
        Destroy(gameObject);
    }

    // create another instance of the game object in scene
    void CloneGameObject()
    {
        rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
        GameObject.Instantiate(this.gameObject, originalPosition, originalRotation, this.gameObject.transform.parent);
    }
}