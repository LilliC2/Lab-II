using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controllers : Singleton<Level2Controllers>
{
    [Header("Pieces and Tray")]
    public GameObject layer1TrayPieces;
    public GameObject layer2TrayPieces;

    [Header("Tray")]
    public GameObject layer1Tray;
    public GameObject layer2Tray;

    public GameObject layer1Protection;
    public GameObject layer2Protection;

    [Header("Pieces")]
    public GameObject layer1Pieces;
    public GameObject layer2Pieces;

    [Header("Camera")]
    public GameObject cameraPosInPuzzle;
    public GameObject cameraPosCanvas;
    public GameObject mainCamera;

    bool scatter = false;
    bool scatterRnd = false;
    float layerSpeed = 2;
    public Ease layerEase;
    public Ease pieceScatterEase;

    public GameObject ActiveTrayPos;
    public GameObject DeactiveTrayPos;

    bool moveOver;
    bool incrementedHint;

    [Header("UI")]
    public GameObject hintCanvas;
    float hintsUsed;
    public GameObject finishedImage;
    public TMP_Text hintsRemaining;
    public GameObject hintWarning;
    public GameObject hintToken1;
    public GameObject hintToken2;
    public GameObject hintToken3;

    [Header("Animation")]
    public Animator layer1Animatior;
    public Animator layer2Animatior;

   

    public enum LayerStatus { Layer1, Layer2 };
    public LayerStatus layerStatus;

    // Start is called before the first frame update
    void Start()
    {

        moveOver = false;
        layerStatus = LayerStatus.Layer1;

    }

    // Update is called once per frame
    void Update()
    {
        if (_GM.gameState == GameManager.GameState.Playing)
        {
            //show complete puzzle
            if (!moveOver)
            {
                ExecuteAfterSeconds(6, () => MovePieces());
                moveOver = true;
            }



            if (!scatterRnd)
            {
                ExecuteAfterSeconds(4, () => ScatterPieces());
                scatterRnd = true;
            }
            //if (moveOver == false) 


            //scatter puzzle
            if (!scatter)
            {
                ExecuteAfterSeconds(7, () => ResetPieces());
                ExecuteAfterSeconds(10, () => scatter = _PPL.RandomisePieces());
            }



            //move camera over to make room for tray
            //ADD WAIT TIME 
            if (layerStatus == LayerStatus.Layer1) ExecuteAfterSeconds(8, () => MoveCamera(cameraPosInPuzzle));


            ExecuteAfterSeconds(10, () => _GM.GameStatePlaying());
            //bring in layer 1 tray
            ExecuteAfterSeconds(10, () => BringTray(1));

            //check if layer 1 is complete
            if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL1) && layerStatus == LayerStatus.Layer1)
            {

                layer1Protection.SetActive(true);

                //remove layer 1 tray
                layer1Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                //bring in layer 2 tray
                ExecuteAfterSeconds(2, () => BringTray(2));
                layerStatus = LayerStatus.Layer2;
            }


            //check if layer 2 is compelte
            if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL2) && layerStatus == LayerStatus.Layer2)
            {
                layer2Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                print("donje");
                //move camera to focus on canvas and remove tray
                ExecuteAfterSeconds(1, () => MoveCamera(cameraPosCanvas));
                //flatten puzzle
                ExecuteAfterSeconds(5, () => FlattenPieces());
                ExecuteAfterSeconds(3, () => _UI.ActivateWinPanel());
                _AC.Victory.Play();

                _GM.gameState = GameManager.GameState.Victory;
            }

        }



    }

    void FlattenPieces()
    {
        layer1Pieces.transform.DOMoveY(0, 3);
        layer2Pieces.transform.DOMoveY(0, 3);
    }

    void ScatterPieces()
    {
        layer1Animatior.SetTrigger("scatter l2");
        layer2Animatior.SetTrigger("scatter l2");


    }

    void ResetPieces()
    {


        layer1Animatior.enabled = false;
        layer2Animatior.enabled = false;
    }
    void MovePieces()
    {
        //return;
        moveOver = true;
        layer1Pieces.transform.DOMoveZ(100, 1f);
        layer2Pieces.transform.DOMoveZ(100f, 1f);


    }

    void BringTray(int _layer)
    {
        _GM.introOver = true;
        switch (_layer)
        {
            case 1:
                //turn on hint button
                hintCanvas.SetActive(true);
                layer1TrayPieces.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
            case 2:
                layer2TrayPieces.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;

        }
    }

    void MoveCamera(GameObject _pos)
    {

        mainCamera.transform.DOMove(_pos.transform.position, 1);
    }

    public void HintsButton()
    {
        if (finishedImage.active == false) incrementedHint = false;
        StartCoroutine(Hints());
    }



    IEnumerator Hints()
    {
        if (hintsUsed < 3)
        {
            if (!incrementedHint)
            {
                hintsUsed++;
                incrementedHint = true;
            }


            finishedImage.SetActive(true);

            yield return new WaitForSeconds(3);

            HintTokenCounter();

            finishedImage.SetActive(false);
        }

    }

    public void HintTokenCounter()
    {
        if (hintsUsed == 1)
            hintToken1.GetComponent<Image>().color = Color.grey;

        if (hintsUsed == 2)
            hintToken2.GetComponent<Image>().color = Color.grey;

        if (hintsUsed == 3)
            hintToken3.GetComponent<Image>().color = Color.grey;
    }

    public void WarningOn()
    {
        hintWarning.SetActive(true);
    }

    public void WarningOff()
    {
        hintWarning.SetActive(false);
    }

   
}
