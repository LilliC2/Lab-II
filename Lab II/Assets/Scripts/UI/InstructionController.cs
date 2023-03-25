using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class InstructionController : GameBehaviour
{
    public GameObject instructionPanel;
    public GameObject ingamePanel;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;

    public void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
        ingamePanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void Page1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
    }

    public void Page2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
    }

    public void Page3()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(true);
        page4.SetActive(false);
        page5.SetActive(false);
    }

    public void Page4()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(true);
        page5.SetActive(false);
    }

    public void Page5()
    {
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
        ingamePanel.SetActive(true);
        _GM.gameState = GameState.Playing;
    }
}

