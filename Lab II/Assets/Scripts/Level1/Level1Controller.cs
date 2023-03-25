using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Level1Controller : Singleton<Level1Controller>
{
    //Gameobjects

    //puzzle pieces and tray
    public GameObject layer1TrayPieces;
    public GameObject layer2TrayPieces;
    public GameObject layer3TrayPieces;

    //just tray
    public GameObject layer1Tray;
    public GameObject layer2Tray;
    public GameObject layer3Tray;

    public GameObject layer1Protection;
    public GameObject layer2Protection;

    //just pieces
    public GameObject layer1Pieces;
    public GameObject layer2Pieces;
    public GameObject layer3Pieces;
    
    public GameObject cameraPosInPuzzle;
    public GameObject cameraPosCanvas;
    public GameObject mainCamera;
    
    bool scatter = false;
    float layerSpeed = 2;
    public Ease layerEase;
    public Ease pieceScatterEase;

    public GameObject ActiveTrayPos;
    public GameObject DeactiveTrayPos;

    bool moveOver;

    public GameObject hintCanvas;
    float hintsUsed;
    public GameObject finishedImage;
    public TMP_Text hintsRemaining;
    public GameObject hintToken1;
    public GameObject hintToken2;
    public GameObject hintToken3;

    public enum LayerStatus { Layer1, Layer2, Layer3 }; 
    public LayerStatus layerStatus;

    // Start is called before the first frame update
    void Start()
    {
        moveOver = false;
        layerStatus = LayerStatus.Layer1;
        ExecuteAfterSeconds(6, () => MovePieces());
    }

    // Update is called once per frame
    void Update()
    {
        if(_GM.gameState == GameManager.GameState.Playing)
        {
            //show complete puzzle

            ExecuteAfterSeconds(2, () => RaisePieces());
            //if (moveOver == false) 


            //scatter puzzle
            if (!scatter) ExecuteAfterSeconds(10, () => scatter = _PPL.RandomisePieces());



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
                layer2Protection.SetActive(true);
                print("level 2 done");
                //remove layer 2 tray
                layer2Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                //bring in layer 3 tray
                ExecuteAfterSeconds(2, () => BringTray(3));
                layerStatus = LayerStatus.Layer3;
            }

            //check if layer 3 is complete
            if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL3) && layerStatus == LayerStatus.Layer3)
            {
                print("donje");
                //move camera to focus on canvas and remove tray
                ExecuteAfterSeconds(1, () => MoveCamera(cameraPosCanvas));
                //flatten puzzle
                ExecuteAfterSeconds(5, () => FlattenPieces());
                _UI.ActivateWinPanel();

                //level complete



            }
        }
        
        ////show complete puzzle

        //ExecuteAfterSeconds(2, () => RaisePieces());
        ////if (moveOver == false) 


        ////scatter puzzle
        //if (!scatter) ExecuteAfterSeconds(10, () => scatter = _PPL.RandomisePieces());



        ////move camera over to make room for tray
        ////ADD WAIT TIME 
        //if(layerStatus == LayerStatus.Layer1) ExecuteAfterSeconds(8, () => MoveCamera(cameraPosInPuzzle));


        //ExecuteAfterSeconds(10, () => _GM.GameStatePlaying());
        ////bring in layer 1 tray
        //ExecuteAfterSeconds(10, () => BringTray(1));

        ////check if layer 1 is complete
        //if(_PPL.CheckLayerStatus(_PPL.puzzlePiecesL1) && layerStatus == LayerStatus.Layer1)
        //{
        //    layer1Protection.SetActive(true);

        //    //remove layer 1 tray
        //    layer1Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
        //    //bring in layer 2 tray
        //    ExecuteAfterSeconds(2, () => BringTray(2));
        //    layerStatus = LayerStatus.Layer2;
        //}


        ////check if layer 2 is compelte
        //if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL2) && layerStatus == LayerStatus.Layer2)
        //{
        //    layer2Protection.SetActive(true);
        //    print("level 2 done");
        //    //remove layer 2 tray
        //    layer2Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
        //    //bring in layer 3 tray
        //    ExecuteAfterSeconds(2, () => BringTray(3));
        //    layerStatus = LayerStatus.Layer3;
        //}

        ////check if layer 3 is complete
        //if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL3) && layerStatus == LayerStatus.Layer3)
        //{
        //    print("donje");
        //    //move camera to focus on canvas and remove tray
        //    ExecuteAfterSeconds(1, () => MoveCamera(cameraPosCanvas));
        //    //flatten puzzle
        //    ExecuteAfterSeconds(5, () => FlattenPieces());
        //    _UI.ActivateWinPanel();

        //    //level complete


        //}



    }

    void FlattenPieces()
    {
        layer1Pieces.transform.DOMoveY(0, 3);
        layer2Pieces.transform.DOMoveY(0, 3);
        layer3Pieces.transform.DOMoveY(0, 3);
    }

    void RaisePieces()
    {
        layer1Pieces.transform.DOMoveY(5f, 3);
        layer2Pieces.transform.DOMoveY(5f, 3);
        layer3Pieces.transform.DOMoveY(5f, 3);
    }

    void MovePieces()
    {
        //currently not working so return to skip this
        //return;
        moveOver = true;
        layer1Pieces.transform.DOMoveX(60f, 1f);
        layer2Pieces.transform.DOMoveX(60f, 1f);
        layer3Pieces.transform.DOMoveX(60f, 1f);
        
        
    }

    void BringTray(int _layer)
    {
        

        switch(_layer)
        {
            case 1:
                //turn on hint button
                hintCanvas.SetActive(true);
                layer1TrayPieces.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
            case 2:
                layer2TrayPieces.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
            case 3:
                layer3TrayPieces.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
        }
    }
    
    void MoveCamera(GameObject _pos)
    {

        mainCamera.transform.DOMove(_pos.transform.position, 1);
    }
    
    public void HintsButton()
    {
        StartCoroutine(Hints());
    }



    IEnumerator Hints()
    {
        if(hintsUsed <3)
        {
            hintsUsed++;

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
}
