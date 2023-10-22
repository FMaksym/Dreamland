using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _playerLevel = 1;
    [SerializeField] private int _playerCurrentScoreAmount;
    [SerializeField] private int _playerMaxScoreForCurrentLevel = 50;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Image _scoreLine;

    private int _levelScoreStage = 100;

    private void Awake()
    {
        LoadData();
        InitializeScore();
    }

    private void InitializeScore()
    {
        _levelText.text = _playerLevel.ToString();
        _scoreText.text = $"{_playerCurrentScoreAmount}/{_playerMaxScoreForCurrentLevel}";
        _scoreLine.fillAmount = ((float)_playerCurrentScoreAmount / _playerMaxScoreForCurrentLevel);
    }

    public void AddScore(int score)
    {
        _playerCurrentScoreAmount += score;
        if (_playerCurrentScoreAmount >= _playerMaxScoreForCurrentLevel)
        {
            _playerMaxScoreForCurrentLevel += _levelScoreStage;
            _playerLevel++;
            _levelText.text = _playerLevel.ToString();
        }

        _scoreLine.fillAmount = ((float)_playerCurrentScoreAmount / _playerMaxScoreForCurrentLevel);
        _scoreText.text = $"{_playerCurrentScoreAmount}/{_playerMaxScoreForCurrentLevel}";
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("PlayerLevel", _playerLevel);
        PlayerPrefs.SetInt("PlayerCurrentScore", _playerCurrentScoreAmount);
        PlayerPrefs.SetInt("PlayerMaxScore", _playerMaxScoreForCurrentLevel);
    }

    private void LoadData()
    {
        _playerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
        _playerCurrentScoreAmount = PlayerPrefs.GetInt("PlayerCurrentScore", 0);
        _playerMaxScoreForCurrentLevel = PlayerPrefs.GetInt("PlayerMaxScore", 50);

        if (_playerLevel <= 0)
        {
            _playerLevel = 1;
        }
        if (_playerMaxScoreForCurrentLevel <= 0)
        {
            _playerMaxScoreForCurrentLevel = 50;
        }
    }
}
