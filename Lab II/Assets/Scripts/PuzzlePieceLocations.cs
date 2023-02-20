using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PuzzlePieceLocations : MonoBehaviour
{

    //classes mighjt be better however idk how to do that

    public Drag dragScript;
    public int row = 11;
    public int col = 2;
    public GameObject[,] puzzlePiecesLocations;



    public int index;
    public GameObject lastObjectHeld;
    bool inRangeOfGoal;


    // Start is called before the first frame update
    void Start()
    {
        //populate 2d array
        puzzlePiecesLocations = new GameObject[col, row];

        for (int i = 0; i  < col; i++)
        {
            print("Before j loop i + " + i);
            for (int j = 0; j < row; j++)
            {
                print(i);
                //find drag pieces
                if (i == 0) puzzlePiecesLocations[i, j] = GameObject.FindGameObjectsWithTag("Drag")[j];
                else if (i == 1) puzzlePiecesLocations[i, j] = GameObject.FindGameObjectsWithTag("solvedPos")[j];

                print(puzzlePiecesLocations[i, j] + "col " + i + " row " + j);


            }
        }


        
    }

    // Update is called once per frame
    void Update()
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
            for (int j = 0; j < row; j++)
            {
                if (puzzlePiecesLocations[0, j].name == dragScript.selectedObject.name)
                {
                    index = j;

                    if (Vector3.Distance(puzzlePiecesLocations[0, index].transform.position, puzzlePiecesLocations[1, index].transform.position) < 0.5) 
                    {
                        inRangeOfGoal = true;
                        print("CLOSE");
                        //lastObjectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
                    }
                    else inRangeOfGoal = false;
                }
            }
            
        }

        //when item is dropped, make last object held unable to be picked up and set position
        if(dragScript.selectedObject == null && inRangeOfGoal == true)
        {
            lastObjectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
            lastObjectHeld.tag = "complete";
        }
    }

  

    
}
