using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePieceLocations : MonoBehaviour
{

    //classes mighjt be better however idk how to do that

    public Drag dragScript;
    public int row = 3;
    public int col = 1;
    public GameObject[,] puzzlePiecesLocations; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        //populate 2d array
        puzzlePiecesLocations = new GameObject[col, row];

        for(int i = 0; i < col; i++)
        {
            for(int j = 0; j < row; j++)
            {
                //find drag pieces
                if(i == 0) puzzlePiecesLocations[i, j] = GameObject.FindGameObjectsWithTag("Drag")[j];
                if(i== 1) puzzlePiecesLocations[i, j] = GameObject.FindGameObjectsWithTag("solvedPos")[j];
                
                //print(puzzlePiecesLocations[i,j]);
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
            GameObject objectHeld = dragScript.selectedObject;
            print("object grabbed");
            print(objectHeld.name);

            //find object in array
            for (int j = 0; j < row; j++)
            {
                if (puzzlePiecesLocations[0, j].name == dragScript.selectedObject.name)
                {
                    int index = j;

                    if (Vector3.Distance(puzzlePiecesLocations[0, index].transform.position, puzzlePiecesLocations[1, index].transform.position) < 0.5) 
                    {
                        
                        print("CLOSE");
                        objectHeld.transform.position = puzzlePiecesLocations[1, index].transform.position;
                    }
                }
            }
            
        }

    }




    
}
