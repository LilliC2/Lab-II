using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }

    public void ActivateWinPanel()
    {
        winPanel.SetActive(true);
    }
}
