using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text _highScoreText;
    [SerializeField] private TextMeshProUGUI _playerNameText;

    private void Awake()
    {
        PlayerName();
        HighscoreDisplay();
    }

    private void PlayerName()
    {
        if(Highscore.Instance != null)
            _playerNameText.text = $"Player: {Highscore.Instance.PlayerName}";
    }

    private void HighscoreDisplay()
    {
        if (Highscore.Instance != null && !string.IsNullOrEmpty(Highscore.Instance.PlayerName))
            _highScoreText.text = $"Bestscore:\n{Highscore.Instance.PlayerNameHighscore}: {Highscore.Instance.HighScore}";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
