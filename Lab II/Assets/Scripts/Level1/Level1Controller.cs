using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public enum LayerStatus { Layer1, Layer2, Layer3 }; 
    public LayerStatus layerStatus;

    // Start is called before the first frame update
    void Start()
    {
        layerStatus = LayerStatus.Layer1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //show complete puzzle

        ExecuteAfterSeconds(2, () => RaisePieces());
        //scatter puzzle
        if (!scatter) ExecuteAfterSeconds(6, () => scatter = _PPL.RandomisePieces());



        //move camera over to make room for tray
        //ADD WAIT TIME 
        mainCamera.transform.DOMove(cameraPosInPuzzle.transform.position, 1);


        //bring in layer 1 tray
        ExecuteAfterSeconds(15, () => BringTray(1));

        //check if layer 1 is complete
        if(_PPL.CheckLayerStatus(_PPL.puzzlePiecesL1) && layerStatus == LayerStatus.Layer1)
        {
            //remove layer 1 tray
            layer1Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
            //bring in layer 2 tray
            ExecuteAfterSeconds(2, () => BringTray(2));
            layerStatus = LayerStatus.Layer2;
        }


        //check if layer 2 is compelte
        if (_PPL.CheckLayerStatus(_PPL.puzzlePiecesL2) && layerStatus == LayerStatus.Layer2)
        {
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
            mainCamera.transform.DOMove(cameraPosCanvas.transform.position, 3);
            //flatten puzzle
            ExecuteAfterSeconds(5, () => FlattenPieces());
            _UI.ActivateWinPanel();

            //level complete


        }



    }

    void FlattenPieces()
    {
        layer1Pieces.transform.DOMoveY(0, 3);
        layer2Pieces.transform.DOMoveY(0, 3);
        layer3Pieces.transform.DOMoveY(0, 3);
    }

    void RaisePieces()
    {
        layer1Pieces.transform.DOMoveY(1.42f, 3);
        layer2Pieces.transform.DOMoveY(3.42f, 3);
        layer3Pieces.transform.DOMoveY(4.42f, 3);
    }

    void BringTray(int _layer)
    {
        switch(_layer)
        {
            case 1:
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
    
    
}
