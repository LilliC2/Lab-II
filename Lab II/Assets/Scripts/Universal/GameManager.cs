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

        print(gameState);

    }

    public void GameStatePlaying()
    {
        gameState = GameState.Playing;
    }
}
