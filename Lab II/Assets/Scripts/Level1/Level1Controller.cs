using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1Controller : Singleton<Level1Controller>
{
    //Gameobjects
    public GameObject layer1Tray;
    public GameObject layer2Tray;
    public GameObject layer3Tray;

    public GameObject layer1Pieces;
    public GameObject layer2Pieces;
    public GameObject layer3Pieces;

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


        //scatter puzzle
        if(!scatter) ExecuteAfterSeconds(2, () => scatter = _PPL.RandomisePieces());



        //move camera over to make room for tray




        //bring in layer 1 tray
        //turn on mouse

        ExecuteAfterSeconds(6, () => BringTray(1));

        //check if layer 1 is complete

        //turn off mouse
        //remove layer 1

        //layer1Tray.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
        //bring in layer 2 tray

        //layer2Tray.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);

        //check if layer 2 is compelte

        //bring in layer 3 tray
        //layer3Tray.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
        //check if layer 3 is complete

        //move camera to focus on canvas and remove tray

        //flatten puzzle

        //level complete


    }

    void BringTray(int _layer)
    {
        switch(_layer)
        {
            case 1:
                layer1Tray.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
            case 2:
                layer2Tray.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
            case 3:
                layer3Tray.transform.DOMove(ActiveTrayPos.transform.position, layerSpeed).SetEase(layerEase);
                break;
        }
    }
    
    
    void ScatterPieces()
    {
        layer1Pieces.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(pieceScatterEase);
        layer2Pieces.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(pieceScatterEase);
        layer3Pieces.transform.DOMove(DeactiveTrayPos.transform.position, layerSpeed).SetEase(pieceScatterEase);
    }
}
