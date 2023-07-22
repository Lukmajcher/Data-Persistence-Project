using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
        [Header("Reference:")]
        [SerializeField] private Button StarGameButton;
        [SerializeField] private Button HighScoreButton;
        [SerializeField] private Button QuitGameButton;
        [SerializeField] private Button BackToMenuButton;
        [SerializeField] private TMP_InputField NameInputField;
    */
    public static GameManager Instance { get; private set; }

    public string Name;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
