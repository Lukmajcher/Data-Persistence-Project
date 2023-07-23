using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreUIHandler : MonoBehaviour
{
    [SerializeField] private Button _backToMenuButton;

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
