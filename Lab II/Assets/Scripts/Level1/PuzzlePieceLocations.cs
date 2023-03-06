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

    bool rotating = false;

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
                print(puzzlePiecesEndPosL1);
                if (_puzzlePieces[j].name == dragScript.selectedObject.name)
                {
                    snapped = false;
                    index = j;

                    print(j);

                    

# region aniamtion
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 5)
                    {
                        inRangeOfGoal = true;
                        print("CLOSE");

                        
                        //lastObjectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
                    }
                    else inRangeOfGoal = false;



                    //HAPPY EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 3 )
                    {
                        //print("Happy");
                        _CA.face = CharacterAnimator.Face.happy;

                    }//SMILE EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 3.1 && Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 10)
                    {
                       // print("Smile");
                        _CA.face = CharacterAnimator.Face.smile;

                    }

                    //NEUTRAL EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 10.1 && Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) < 30)
                    {
                       // print("Neutral");
                        _CA.face = CharacterAnimator.Face.reset;

                    }
                    //SAD EMOTE
                    if (Vector3.Distance(_puzzlePieces[j].transform.position, _puzzlePiecesEndPos[j].transform.position) > 30.1)
                    {
                     //    print("Sad");
                        _CA.face = CharacterAnimator.Face.sad;

                    }
                    # endregion
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                //if not 360
                if(!rotating)
                {
                    rotating = true;
                    Vector3 goalRotation = lastObjectHeld.transform.eulerAngles + new Vector3(0, 90, 0);
                    lastObjectHeld.transform.DORotate(goalRotation, 1);

                    print("Rotating to: " + (lastObjectHeld.transform.eulerAngles + new Vector3(0, 90, 0), 1));
                    print("Rotating");
                    ExecuteAfterSeconds(1, () => RotatingReset());

                }
                
            }
        }

        //when item is dropped, make last object held unable to be picked up and set position
        if (dragScript.selectedObject == null && inRangeOfGoal == true)
        {
            print("Goal rotation: " + _puzzlePiecesEndPos[index].transform.rotation.y);
            print("Piece rotation: " + lastObjectHeld.transform.rotation.y);

            //Check if rotation is the same
            if (lastObjectHeld.transform.rotation.y - _puzzlePiecesEndPos[index].transform.rotation.z < 0.5)
            {
                print("Correct Rotation");
                if (!snapped)
                {
                    print("snap!");
                    lastObjectHeld.transform.position = _puzzlePiecesEndPos[index].transform.position;
                    lastObjectHeld.transform.rotation = _puzzlePiecesEndPos[index].transform.rotation;

                    lastObjectHeld.tag = "complete";
                    snapped = true;
                }
            }
            
            
            return;
        }
    }

    void RotatingReset()
    {
        rotating = false;
    }

    /// <summary>
    /// Moves puzzle pieces to a random location on the tray
    /// </summary>
    /// <returns></returns>
    public bool RandomisePieces()
    {
        int[] rotations = new int [4];
        rotations[0] = 0;
        rotations[1] = 90;
        rotations[2] = 180;
        rotations[3] = 270;

        float scatterTime = 2;
        bool scatter = true;
        for (int i = 0; i < puzzlePiecesL1.Length; i++)
        {
            puzzlePiecesL1[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL1[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime);

            int num = rotations[UnityEngine.Random.Range(0, 3)];
            puzzlePiecesL1[i].gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Round(num));
        }
        for (int i = 0; i < puzzlePiecesL2.Length; i++)
        {
            int num = rotations[UnityEngine.Random.Range(0, 3)];
            puzzlePiecesL2[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL2[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime); 
            puzzlePiecesL2[i].gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Round(num));
        }

        for (int i = 0; i < puzzlePiecesL3.Length; i++)
        {
            int num = rotations[UnityEngine.Random.Range(0, 3)];
            puzzlePiecesL3[i].gameObject.transform.DOMove(new Vector3(UnityEngine.Random.Range(62.1f, 43.63f), puzzlePiecesL3[i].gameObject.transform.position.y, UnityEngine.Random.Range(-13.75f, 13.75f)), scatterTime);
            puzzlePiecesL3[i].gameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Round(num));
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
