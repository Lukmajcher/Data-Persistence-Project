using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Windows;
using UnityEngine.UI;
using System.Xml.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private TextMeshProUGUI _playerNameText;


    private string _playerName;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            NamePlayer();
        }
    }

    public void SetPlayerName(string input)
    {
        if (input == string.Empty)
            return;

        _playerName = _nameInputField.text;
        GameManager.Instance.Name = _playerName;
        Debug.Log(GameManager.Instance.Name);
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void HighscoreTable()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void NamePlayer()
    {
        _playerNameText.text = GameManager.Instance.Name;
    }
}
