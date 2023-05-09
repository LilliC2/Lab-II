using DG.Tweening;
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

    public CanvasGroup cvs;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cvs.alpha = 0;
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

    public void FadeOut()
    {
        FadeCanvas(1);
    }

    void FadeCanvas(float _fadeTo)
    {
        cvs.DOFade(_fadeTo, 2);
    }
}
