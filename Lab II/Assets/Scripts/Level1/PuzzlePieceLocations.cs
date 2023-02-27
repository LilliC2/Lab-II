using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PuzzlePieceLocations : Singleton<PuzzlePieceLocations>
{

    //classes mighjt be better however idk how to do that

    public Drag dragScript;
    public int row = 11;
    public int col = 2;
    //public GameObject[,] puzzlePiecesLocations;

    public GameObject[] puzzlePiecesL1;
    public GameObject[] puzzlePiecesL2;
    public GameObject[] puzzlePiecesL3;
    public GameObject[] puzzlePiecesEndPosL1;
    public GameObject[] puzzlePiecesEndPosL2;
    public GameObject[] puzzlePiecesEndPosL3;
    bool[] completeionL1;
    bool[] completeionL2;
    bool[] completeionL3;

    public GameObject[,] puzzlePiecesLocations;
    bool snapped = false;

    public Ease rotation;

    public int index;
    public GameObject lastObjectHeld;
    bool inRangeOfGoal;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        switch(_L1C.layerStatus)
        {
            case Level1Controller.LayerStatus.Layer1:
                DragAndDropPuzzlePieces(puzzlePiecesL1, puzzlePiecesEndPosL1);
                break;
            case Level1Controller.LayerStatus.Layer2:
                DragAndDropPuzzlePieces(puzzlePiecesL2, puzzlePiecesEndPosL2);
                break;
            case Level1Controller.LayerStatus.Layer3:
                DragAndDropPuzzlePieces(puzzlePiecesL3, puzzlePiecesEndPosL3);
                break;

        }
    }

    /// <summary>
    /// Checks if selected puzzle piece is close to the target location, if so snaps it, changes tag and updates completetion array
    /// </summary>
    /// <param name="_puzzlePieces"></param>
    /// <param name="_puzzlePiecesEndPos"></param>
    /// <param name="_completetion"></param>
    void DragAndDropPuzzlePieces(GameObject[] _puzzlePieces, GameObject[] _puzzlePiecesEndPos)

    {
        //check if object is close to puzzle location
        //set location to puzzle location

        //check if player is dragging an object
        if (dragScript.selectedObject != null)
        {
            lastObjectHeld = dragScript.selectedObject;
            print("object grabbed");
            print(lastObjectHeld.name);

            //find object in array
            for (int j = 0; j < _puzzlePieces.Length; j++)
            {
                if (_puzzlePieces[j].name == dragScript.selectedObject.name)
                {
                    snapped = false;
                    index = j;

                    print(j);

                    

# region aniamtion
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 2)
                    {
                        inRangeOfGoal = true;
                        
                        //lastObjectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
                    }
                    else inRangeOfGoal = false;



                    //HAPPY EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 3 )
                    {
                        print("Happy");
                        _CA.face = CharacterAnimator.Face.happy;

                    }//SMILE EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 3.1 && Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 10)
                    {
                        print("Smile");
                        _CA.face = CharacterAnimator.Face.smile;

                    }

                    //NEUTRAL EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 10.1 && Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 30)
                    {
                        print("Neutral");
                        _CA.face = CharacterAnimator.Face.reset;

                    }
                    //SAD EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 30.1)
                    {
                        print("Sad");
                        _CA.face = CharacterAnimator.Face.sad;

                    }
                    # endregion
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                lastObjectHeld.transform.DORotate(lastObjectHeld.transform.eulerAngles + new Vector3(0,90,0),1);
                print("Rotating");
            }
        }

        //when item is dropped, make last object held unable to be picked up and set position
        if (dragScript.selectedObject == null && inRangeOfGoal == true)
        {
            
            if(!snapped)
            {
                lastObjectHeld.transform.position = _puzzlePiecesEndPos[index].transform.position;
                snapped = true;
            }
            
            lastObjectHeld.tag = "complete";
            return;
        }
    }

    /// <summary>
    /// Moves puzzle pieces to a random location on the tray
    /// </summary>
    /// <returns></returns>
    public bool RandomisePieces()
    {
        float scatterTime = 3;
        bool scatter = true;
        for (int i = 0; i < 4; i++)
        {
            puzzlePiecesL1[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL1[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime);
            puzzlePiecesL2[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL2[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime);
            puzzlePiecesL3[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL3[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime);
        }
        return scatter;
    }

    /// <summary>
    /// Checks if all pieces in current layer are in target locations
    /// </summary>
    /// <param name="_puzzlePieces"></param>
    /// <returns>If layer is complete</returns>
    public bool CheckLayerStatus(GameObject[] _puzzlePieces)
    {
        bool complete = true;
        for(int i = 0; i < _puzzlePieces.Length; i++)
        {
            if(_puzzlePieces[i].tag != "complete")
            {
                complete = false;
                break;
            }
        }

        return complete;

    }



}
