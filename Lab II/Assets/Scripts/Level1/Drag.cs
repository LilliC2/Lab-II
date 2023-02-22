using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : GameBehaviour
{
    public GameObject selectedObject;
    float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //left click
        if(Input.GetMouseButtonDown(0))
        {
            //no object selected
            if(selectedObject == null)
            {
                //assign object and pick something up
                RaycastHit hit = CastRay();

                //did we hit something
                if(hit.collider != null)
                {
                    //check for drag tag, is dragable
                    if (!hit.collider.CompareTag("Drag") && hit.collider.gameObject.layer != CheckLayer()) 
                        return; //exit
                    selectedObject = hit.collider.gameObject;
                    objectHeight = selectedObject.transform.position.y;
                    Cursor.visible = false; //remove cursor since gameobject is same pos as cursor
                }
            }
            //object selected
            else
            {
                //set object down
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

                //set gameobject pos to mouse pos, lower back down
                selectedObject.transform.position = new Vector3(worldPosition.x, objectHeight, worldPosition.z);

                

                //reset object
                selectedObject = null;
                Cursor.visible = true;

            }
        }

        //when object is picked up
        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            //set gameobject pos to mouse pos
            selectedObject.transform.position = new Vector3(worldPosition.x,objectHeight * 1.25f, worldPosition.z); 

        }
    }

    private int CheckLayer()
    {
        int layer = 0;
        switch(_L1C.layerStatus)
        {
            case Level1Controller.LayerStatus.Layer1:
                layer = 6;
                break;
            case Level1Controller.LayerStatus.Layer2:
                layer = 7;
                break;
                    case Level1Controller.LayerStatus.Layer3:
                layer = 8;
                break;
        }
        return layer;
    }

    /// <summary>
    /// Raycast from mousep position
    /// </summary>
    /// <returns>Raycast hit</returns>
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}

