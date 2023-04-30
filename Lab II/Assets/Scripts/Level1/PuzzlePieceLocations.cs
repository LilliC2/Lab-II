using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.TextCore.Text;


public class PuzzlePieceLocations : Singleton<PuzzlePieceLocations>
{

    
    public Drag dragScript;
    public int row = 11;
    public int col = 2;

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

    bool l1compelete = false;
    bool l2compelete = false;
    bool l3compelete = false;

    public int index;
    public GameObject lastObjectHeld = null;
    bool inRangeOfGoal;

    Vector3 pieceScale = new Vector3(1, 1, 1);

    bool rotating = false;

    bool rectangele;
    bool hasReset = false;

    bool nameSame;
    bool misclickSoundPlayed;

    [Header("Reaction Radius")]
    public float happyRadius;
    public float smileRadius;
    public float neutralRadius;
    GameObject endPos;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(_GM.levelState == GameManager.LevelState.Level1 && _GM.gameState == GameManager.GameState.Playing && _GM.introOver)
        {
            switch (_L1C.layerStatus)
            {
                case Level1Controller.LayerStatus.Layer1:
                    DragAndDropPuzzlePieces(puzzlePiecesL1, puzzlePiecesEndPosL1);

                    break;
                case Level1Controller.LayerStatus.Layer2:
                    DragAndDropPuzzlePieces(puzzlePiecesL2, puzzlePiecesEndPosL2);
                    break;
                case Level1Controller.LayerStatus.Layer3:
                    DragAndDropPuzzlePieces(puzzlePiecesL3, puzzlePiecesEndPosL3);
                    happyRadius = 5;
                    smileRadius = 12;
                    neutralRadius = 18;
                    break;

            }
        }
        else if(_GM.levelState == GameManager.LevelState.Level2 && _GM.gameState == GameManager.GameState.Playing && _GM.introOver)
        {

            

            switch (_L2C.layerStatus)
            {

                case Level2Controllers.LayerStatus.Layer1:
                    DragAndDropPuzzlePieces(puzzlePiecesL1, puzzlePiecesEndPosL1);

                    break;
                case Level2Controllers.LayerStatus.Layer2:
                    DragAndDropPuzzlePieces(puzzlePiecesL2, puzzlePiecesEndPosL2);
                    break;
                

            }
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
        //check if player is dragging an object
        if (dragScript.selectedObject != null)
        {
            misclickSoundPlayed = false;
            hasReset = false;
            lastObjectHeld = dragScript.selectedObject;

            //find object in array
            for (int j = 0; j < _puzzlePieces.Length; j++)
            {
                if (_puzzlePieces[j].name == dragScript.selectedObject.name)
                {
                    print(_puzzlePieces[j].name + dragScript.selectedObject.name);
                    nameSame = true;
                    index = j;
                }
                
                    
            }

            if (nameSame)
            {
                print("Name is the same");
                snapped = false;
                //index = i;
                endPos = _puzzlePiecesEndPos[index];

                #region aniamtion
                if (Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < happyRadius)
                {
                    inRangeOfGoal = true;

                    
                    //lastObjectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
                }
                else inRangeOfGoal = false;




                if (_puzzlePieces[index].transform.eulerAngles.y == 270 && Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < happyRadius)
                {
                    //Right rotation 270
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Right;
                }
                else if (_puzzlePieces[index].transform.eulerAngles.y == 180 && Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < happyRadius)
                {

                    if (_puzzlePieces[index].name == "RedRectangle")
                    {
                        rectangele = true;
                        _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Correct;
                    }
                    else
                    { //Multiple rotation
                        _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Spin;
                    }

                }
                else if (_puzzlePieces[index].transform.eulerAngles.y == 90 && Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < happyRadius)
                {
                    //Left rotation 180
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Left;

                }
                //HAPPY EMOTE
                else if (Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < happyRadius && (_puzzlePieces[index].transform.eulerAngles.y <= 1) && _puzzlePieces[index].transform.eulerAngles.y > -1)
                {
                    //_CA.face = CharacterAnimator.Face.happy;
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Correct;

                }
                //SMILE EMOTE
                if (Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) > happyRadius && Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < smileRadius)
                {
                    // print("Smile");
                    //_CA.face = CharacterAnimator.Face.smile;
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Close;

                }

                //NEUTRAL EMOTE
                if (Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) > smileRadius && Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) < neutralRadius)
                {
                    // print("Neutral");
                    //_CA.face = CharacterAnimator.Face.reset;
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Medium;

                }
                //SAD EMOTE
                if (Vector3.Distance(_puzzlePieces[index].transform.position, _puzzlePiecesEndPos[index].transform.position) > neutralRadius)
                {
                    //    print("Sad");
                    //_CA.face = CharacterAnimator.Face.sad;
                    _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Far;

                }
                #endregion
            }

            //while object held, outline
            lastObjectHeld.GetComponent<Outline>().enabled = true;

            //rotate to the right
            if (Input.GetKeyDown(KeyCode.E))
            {
                //print("Rotate R");
                //if not 360
                if(!rotating)
                {
                    rotating = true;
                    Vector3 goalRotation = lastObjectHeld.transform.eulerAngles + new Vector3(0, 90, 0);
                    lastObjectHeld.transform.DORotate(goalRotation, 1);

                    ExecuteAfterSeconds(1, () => RotatingReset());

                }
                
            }

            //rotate to the left
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //print("Rotate Q");

                //if not 360
                if (!rotating)
                {
                    rotating = true;
                    Vector3 goalRotation = lastObjectHeld.transform.eulerAngles + new Vector3(0, -90, 0);
                    lastObjectHeld.transform.DORotate(goalRotation, 1);

                    ExecuteAfterSeconds(1, () => RotatingReset());

                }

            }


        }


        //turn off outline
        if(dragScript.selectedObject == null) lastObjectHeld.GetComponent<Outline>().enabled = false;

        //object in range of pallette
        if (dragScript.selectedObject == null && (lastObjectHeld.transform.position.x > 13 || lastObjectHeld.transform.position.x < -22))
        {
            //make smaller pieces bigger
            if ((_L1C.layerStatus != Level1Controller.LayerStatus.Layer3))
            {
                lastObjectHeld.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                // Vector3 lOHscale =lastObjectHeld.gameObject.transform.localScale;
                //lastObjectHeld.gameObject.transform.localScale = new Vector3(lOHscale.x-2, lOHscale.y-2f, lOHscale.z-2);
            }
            if(lastObjectHeld.name == "HairTriangle") lastObjectHeld.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);

        }
        else
        {
            if ((_L1C.layerStatus != Level1Controller.LayerStatus.Layer3))
            {
                lastObjectHeld.gameObject.transform.localScale = pieceScale;
            }


        }


        if(dragScript.selectedObject == null && !hasReset)
        {
            _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Reset;
            hasReset = true;
            //ExecuteAfterSeconds(2, () => PlayIdle());
        }
        else if (dragScript.selectedObject == null && hasReset)
            ExecuteAfterSeconds(2, () => PlayIdle());

        //when item is dropped, make last object held unable to be picked up and set position
        if (dragScript.selectedObject == null && inRangeOfGoal == true)
        {
            if (lastObjectHeld.name == "RedRectanlge" && lastObjectHeld.transform.rotation.y > -181 && lastObjectHeld.transform.rotation.y < -178)
            {
            }

            //Check if rotation is the same
            if ((lastObjectHeld.transform.rotation.y - _puzzlePiecesEndPos[index].transform.rotation.z < 0.5) || rectangele)
            {
                if (!snapped)
                {
                    lastObjectHeld.transform.position = _puzzlePiecesEndPos[index].transform.position;
                    lastObjectHeld.transform.rotation = _puzzlePiecesEndPos[index].transform.rotation;
                    lastObjectHeld.transform.localScale = pieceScale;



                    lastObjectHeld.tag = "complete";

                    _SA.Snap(_puzzlePiecesEndPos[index]);

                    _AC.snapChime.Play();
                    snapped = true;
                }
            }



            if (lastObjectHeld.name == "RedRectangle")

                return;
        }
        //misclick nosie
        else if (dragScript.selectedObject == null && inRangeOfGoal == false)
        {
            if(!misclickSoundPlayed)
            {
                _AC.pieceMisclick.Play();
                misclickSoundPlayed = true;
            }
            
        }
    }

    public void PlayIdle()
    {
        _PA.characterEmotion = ProtagonistAnimator.CharacterEmotion.Idle;
        
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

        bool scatter = true;

        if(!l1compelete)
        {
            for (int i = 0; i < puzzlePiecesL1.Length; i++)
            {


                puzzlePiecesL1[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                puzzlePiecesL1[i].gameObject.transform.position = (new Vector3(UnityEngine.Random.Range(88.8f, 74.1f), 5, UnityEngine.Random.Range(10f, -3.4f)));

                int num = rotations[UnityEngine.Random.Range(0, 3)];
                puzzlePiecesL1[i].gameObject.transform.eulerAngles = new Vector3(0, Mathf.Round(num), 0);
                if (i == puzzlePiecesL1.Length-1) l1compelete = true;
            }

        }

        if (!l2compelete)
        {
            for (int i = 0; i < puzzlePiecesL2.Length; i++)
            {
                if(puzzlePiecesL2[i].name == "HairTriangle")
                {
                    puzzlePiecesL2[i].gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                }
                else puzzlePiecesL2[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);



                puzzlePiecesL2[i].gameObject.transform.position = (new Vector3(UnityEngine.Random.Range(88.8f, 74.1f),5, UnityEngine.Random.Range(10f, -3.4f)));

                int num = rotations[UnityEngine.Random.Range(0, 3)];
                puzzlePiecesL2[i].gameObject.transform.eulerAngles = new Vector3(0, Mathf.Round(num), 0);
                if (i == puzzlePiecesL2.Length - 1) l2compelete = true;
            }

        }if (!l3compelete)
        {
            for (int i = 0; i < puzzlePiecesL3.Length; i++)
            {


                puzzlePiecesL3[i].gameObject.transform.localScale = new Vector3(1, 1, 1);

                puzzlePiecesL3[i].gameObject.transform.position = (new Vector3(UnityEngine.Random.Range(82.8f, 68.36f), 8, UnityEngine.Random.Range(10f, -1)));

                int num = rotations[UnityEngine.Random.Range(0, 3)];
                puzzlePiecesL3[i].gameObject.transform.eulerAngles = new Vector3(0, Mathf.Round(num), 0);
                if (i == puzzlePiecesL3.Length - 1) l3compelete = true;
            }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(endPos.transform.position, happyRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(endPos.transform.position, smileRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(endPos.transform.position, neutralRadius);

    }

}
