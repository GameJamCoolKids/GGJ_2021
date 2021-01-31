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

    private void Start()
    {
        button.onClick.AddListener(delegate {
            gameController.StartLevel(gameController.GetCurrentLevel()); });
    }
}
