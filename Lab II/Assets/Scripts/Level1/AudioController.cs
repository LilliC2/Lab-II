using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : GameBehaviour
{
    public AudioSource neutralAS;
    public AudioSource sadAS;
    public AudioSource smileAS;
    public AudioSource happyAS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_CA.face)
        {
            case CharacterAnimator.Face.reset:
                break;
            case CharacterAnimator.Face.sad:
                break;
            case CharacterAnimator.Face.smile:
                break;
            case CharacterAnimator.Face.happy:
                break;

        }
    }
}
