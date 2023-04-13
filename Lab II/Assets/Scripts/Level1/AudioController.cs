using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : GameBehaviour
{
    public AudioSource neutralAS;
    public AudioSource farAS;
    public AudioSource almostAS;
    public AudioSource correctAS;
    public AudioSource spinAS;
    public AudioSource closeAS;


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

                //turn off other sounds
                if (closeAS.isPlaying) closeAS.Stop();
                if (correctAS.isPlaying) correctAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                if (!neutralAS.isPlaying) neutralAS.Play();

                print("Play neutral noise");

                break;
            case CharacterAnimator.Face.sad:

                //turn off other sounds
                if(neutralAS.isPlaying) neutralAS.Stop();
                if(closeAS.isPlaying) closeAS.Stop();
                if(correctAS.isPlaying) correctAS.Stop();

                if (!farAS.isPlaying) farAS.Play();

                print("Play sad noise");

                break;
            case CharacterAnimator.Face.smile:

                //turn off other sounds
                if (neutralAS.isPlaying) neutralAS.Stop();
                if (correctAS.isPlaying) correctAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                if (!closeAS.isPlaying) closeAS.Play();
                print("Play close noise");

                break;
            case CharacterAnimator.Face.happy:
                //turn off other sounds
                if (neutralAS.isPlaying) neutralAS.Stop();
                if (closeAS.isPlaying) closeAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                if (correctAS.isPlaying) correctAS.Play();
                print("Play correct noise");

                break;

        }
    }

    
}
