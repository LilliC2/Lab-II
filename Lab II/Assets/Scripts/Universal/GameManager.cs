using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Instructions, Playing, Pause, Title, Victory
    }
    public GameState gameState;
    public enum LevelState { Level1, Level2 }
    public LevelState levelState;

    public bool isPlaying;
    public bool isPaused;

    public bool introOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //Instructions game state
        if (SceneManager.GetActiveScene().name == "Assembly")
        {
            gameState = GameState.Instructions;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //change lvl state
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            levelState = LevelState.Level1;
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            levelState = LevelState.Level2;
        }

        if (gameState == GameState.Playing)
        {
            isPlaying = true;
            isPaused = false;
        }


        if (gameState == GameState.Pause)
        {
            isPlaying = false;
            isPaused = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape) && isPlaying)
        {
            OnPause();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            OnResume();
        }

        if(gameState == GameState.Victory)
        {
            
        }

    }

    public void GameStatePlaying()
    {
        gameState = GameState.Playing;
    }

    public void OnPause()
    {
        gameState = GameState.Pause;
        _UI.OnPause();
        Time.timeScale = 0;
    }

    public void OnResume()
    {
        gameState = GameState.Playing;
        _UI.OnResume();
        Time.timeScale = 1;
    }
}
