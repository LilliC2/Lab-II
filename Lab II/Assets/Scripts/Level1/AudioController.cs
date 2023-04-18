using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    public AudioSource neutralAS;
    public AudioSource farAS;
    public AudioSource almostAS;
    public AudioSource correctAS;
    public AudioSource spinAS;
    public AudioSource closeAS;



    public AudioSource snapChime;
    public AudioSource Victory;


    int random;
    bool randomised;

    string prevFaceState;

    // Start is called before the first frame update
    void Start()
    {
        CheckIfFaceStateChanged();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!randomised)
        {
            random = RandomIntBetweenTwoInt(1, 3);
            randomised = true;
        }

        

        switch(_CA.face)
        {
            case CharacterAnimator.Face.reset:

                //turn off other sounds
                if (closeAS.isPlaying) closeAS.Stop();
                if (correctAS.isPlaying) correctAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                //1/3 chance to play sound
                if (!neutralAS.isPlaying && random == 3) neutralAS.Play();

                print("Play neutral noise");

                break;
            case CharacterAnimator.Face.sad:

                //turn off other sounds
                if(neutralAS.isPlaying) neutralAS.Stop();
                if(closeAS.isPlaying) closeAS.Stop();
                if(correctAS.isPlaying) correctAS.Stop();

                if (!farAS.isPlaying && random == 3) farAS.Play();

                print("Play sad noise");

                break;
            case CharacterAnimator.Face.smile:

                //turn off other sounds
                if (neutralAS.isPlaying) neutralAS.Stop();
                if (correctAS.isPlaying) correctAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                if (!closeAS.isPlaying && random == 3) closeAS.Play();
                print("Play close noise");

                break;
            case CharacterAnimator.Face.happy:
                //turn off other sounds
                if (neutralAS.isPlaying) neutralAS.Stop();
                if (closeAS.isPlaying) closeAS.Stop();
                if (farAS.isPlaying) farAS.Stop();

                if (correctAS.isPlaying && random == 3) correctAS.Play();
                print("Play correct noise");

                break;

        }
        CheckIfFaceStateChanged();
    }

    void CheckIfFaceStateChanged()
    {
        if((_CA.face).ToString() != prevFaceState)
        {
            prevFaceState = _CA.face.ToString();
            randomised = false;
        }

    }
}
