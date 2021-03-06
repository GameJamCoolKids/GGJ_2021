﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]

public class Ingredient : MonoBehaviour
{
    public Enums.Ingredient ingredient;
    public Rigidbody2D rigidBody2D;
    public AudioSource audioSource;

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

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        audioSource.PlayOneShot(audioSource.clip);
        rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        // deactivate recipe ui
        GameObject recipeUI = GameObject.Find("RecipeBook");
        if (recipeUI && recipeUI.activeSelf)
        {
            recipeUI.SetActive(false);
        }
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    // Disable the behaviour when it becomes invisible...
    private void Update()
    {
        if (transform.position.y < -20)
        {
            CloneGameObject();
            Destroy(gameObject);
        }
    }

    // create another instance of the game object in scene
    void CloneGameObject()
    {
        rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
        GameObject.Instantiate(this.gameObject, originalPosition, originalRotation, this.gameObject.transform.parent);
    }
}