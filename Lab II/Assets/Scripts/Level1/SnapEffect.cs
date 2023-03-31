using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapEffect : Singleton<SnapEffect>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Snap (GameObject _correctPiece)
    {
        ParticleSystem light = _correctPiece.GetComponentInChildren<ParticleSystem>(true);

        light.Play(true);

    }
}
