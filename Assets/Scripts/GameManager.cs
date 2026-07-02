using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<string> levels;
    [SerializeField] string finishLevel;

    int currentSceneIndex;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        RestartGame();
    }

    public void ResetLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(levels[currentSceneIndex]);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < levels.Count)
        {
            currentSceneIndex = nextSceneIndex;
            SceneManager.LoadScene(levels[currentSceneIndex]);
        }
        else
        {
            SceneManager.LoadScene(finishLevel);
        }
    }

    public void RestartGame()
    {
        currentSceneIndex = 0;
        SceneManager.LoadScene(levels[currentSceneIndex]);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
