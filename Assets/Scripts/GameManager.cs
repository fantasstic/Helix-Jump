using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _startMenuPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _currentLevelText;  
    [SerializeField] private LevelSettings[] _levelSettings;

    private int _nextSceneToLoad;
    private int _currentSceneToLoad;

    public static bool GameOver;
    public static bool LevelCompleted;
    public static bool Mute = false;

    public static LevelSettings CurrentLevelSettings;

    private void Start()
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(gameObject);
        LoadFirstLevel();
    }

    private void LoadFirstLevel()
    {
        LoadLevel(1);
        _canvas.gameObject.SetActive(true);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        _currentSceneToLoad = levelIndex;
        _nextSceneToLoad = levelIndex + 1;
        CurrentLevelSettings = _levelSettings[levelIndex - 1];
        _currentLevelText.text = levelIndex.ToString();
    }

    public void LoadNextLevel()
    {
        LoadLevel(_nextSceneToLoad);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            _startMenuPanel.SetActive(false);
            _gamePanel.SetActive(true);
        }

        if (GameOver)
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);

            if(Input.touchCount > 0)
            {
                GameOver = false;
                _ball.ResetPlayer();
                Time.timeScale = 1;
                _gameOverPanel.SetActive(false);
                _startMenuPanel.SetActive(true);
                SceneManager.LoadScene(_currentSceneToLoad);
            }
        }

        if (LevelCompleted)
        {
            Time.timeScale = 0;
            _finishPanel.SetActive(true);


            if (Input.touchCount > 0)
            {
                LevelCompleted = false;
                Time.timeScale = 1;
                LoadNextLevel();
                _finishPanel.SetActive(false);
            }
        }
    }
}
