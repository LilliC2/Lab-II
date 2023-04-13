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
    public bool isPlaying;
    public bool isPaused;

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
