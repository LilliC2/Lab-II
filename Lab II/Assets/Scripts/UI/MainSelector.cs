using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSelector : MonoBehaviour
{
    public GameObject cam;
    public GameObject _sC;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(gameObject.name + " is being clicked");
            cam.GetComponent<CameraMovement>().PlayAnimation("Painting" + gameObject.name.ToString());
            StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1.5f);
        _sC.GetComponent<SceneController>().Assembly();
    }
}
