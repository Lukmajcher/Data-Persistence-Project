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
    [SerializeField] private TextMeshProUGUI _highscoreText;

    private string _playerName;

    private void Start()
    {
        if (Highscore.Instance.HighScore == 0)
            _highscoreText.SetText(string.Empty);
        else
            _highscoreText.SetText($"Highscore: {Highscore.Instance.PlayerNameHighscore} - {Highscore.Instance.HighScore} score");
    }

    public void SetPlayerName(string input)
    {
        if (input == string.Empty)
            return;

        _playerName = _nameInputField.text;
        Highscore.Instance.PlayerName = _playerName;
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
        Highscore.Instance.SaveHighscores();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
