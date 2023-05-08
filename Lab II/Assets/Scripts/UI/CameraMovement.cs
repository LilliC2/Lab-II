using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : GameBehaviour
{
    Animator anim;
    public GameObject painting1;
    public GameObject painting2;
    public GameObject painting3;
    public GameObject painting4;

    public GameObject _sC;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(string _string)
    {
        anim.SetTrigger(_string);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Painting1");
        }
    }

    public void Level1()
    {
        _sC.GetComponent<SceneController>().Level1();
    }

    public void Level2()
    {
        _sC.GetComponent<SceneController>().Level2();
    }

    public void Exit()
    {
        _sC.GetComponent<SceneController>().QuitGame();
    }
}
