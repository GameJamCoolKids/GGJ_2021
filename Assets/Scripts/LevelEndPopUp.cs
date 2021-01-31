using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndPopUp : MonoBehaviour
{
    public GameController gameController;
    public TextMeshProUGUI levelEndHeaderTmp;
    public TextMeshProUGUI levelEndButtonTmp;
    public Button button;
    public GameObject screenDimmer;

    private void Start()
    {
        button.onClick.AddListener(delegate {
            gameController.StartLevel(gameController.GetCurrentLevel()); });
    }

    private void OnEnable()
    {
        screenDimmer.SetActive(true);
    }

    private void OnDisable()
    {
        screenDimmer.SetActive(false);
    }
}
