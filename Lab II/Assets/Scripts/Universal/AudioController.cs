using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Protaginist Sounds")]
    [Header("Annoyed")]
    public AudioSource[] annoyedProtag;
    [Header("Flip")]
    public AudioSource[] flipProtag;
    [Header("Happy")]
    public AudioSource[] happyProtag;
    [Header("Intriguie")]
    public AudioSource[] intriguieProtag;
    [Header("Left")]
    public AudioSource[] leftProtag;
    [Header("Mad")]
    public AudioSource[] madProtag;
    [Header("Right")]
    public AudioSource[] rightProtag;
    [Header("Sad")]
    public AudioSource[] sadProtag;
    [Header("Surprised")]
    public AudioSource[] surprisedProtag;
    [Header("Wrong")]
    public AudioSource[] wrongProtag;
    [Header("Almost")]
    public AudioSource[] almostProtag;
    [Header("Close")]
    public AudioSource[] closeProtag;
    [Header("Confused")]
    public AudioSource[] confusedProtag;
    [Header("Correct")]
    public AudioSource[] correctProtag;
    [Header("Neutral")]
    public AudioSource[] neutralProtag;



    [Header("Sound Effects")]
    public AudioSource snapChime;
    public AudioSource Victory;
    public AudioSource buttonClick;
    public AudioSource pieceMisclick;


    public int noiseCooldownTime;
    int random;
    bool randomised;

    bool noiseCoolDownBool = false;
    bool noisePlayed;
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
            random = RandomIntBetweenTwoInt(1, 4);
            print(random);
            randomised = true;
        }
        print(noiseCoolDownBool);
        

        switch(_PA.characterEmotion)
        {
            case ProtagonistAnimator.CharacterEmotion.Idle:

                if (random == 3 && !noiseCoolDownBool && !noisePlayed)
                {
                    noisePlayed = true;
                    RandomiseClip(neutralProtag);
                    StartCoroutine(NoiseCooldown());
                }

                print("Play idle noise");

                break;
            case ProtagonistAnimator.CharacterEmotion.Far:

                //turn off other sounds
                if (random == 3 && !noiseCoolDownBool && !noisePlayed)
                {
                    noisePlayed = true;
                    RandomiseClip(sadProtag);
                    StartCoroutine(NoiseCooldown());
                }

                print("Play far noise");

                break;
            case ProtagonistAnimator.CharacterEmotion.Close:

                if (random == 3 && !noiseCoolDownBool && !noisePlayed)
                {
                    noisePlayed = true;
                    RandomiseClip(closeProtag);
                    StartCoroutine(NoiseCooldown());
                }
                print("Play close noise");
                break;
            case ProtagonistAnimator.CharacterEmotion.Correct:
                //turn off other sounds
                if (random == 3 && !noiseCoolDownBool && !noisePlayed)
                {
                    noisePlayed = true;
                    RandomiseClip(correctProtag);
                    StartCoroutine(NoiseCooldown());
                }
                print("Play correct noise");

                break;

        }
        CheckIfFaceStateChanged();
    }

    void RandomiseClip(AudioSource[] _audioSourceArray)
    {
        _audioSourceArray[RandomIntBetweenTwoInt(0, _audioSourceArray.Length)].Play();
    }

    public void ButtonClick()
    {
        buttonClick.Play();
    }
    void CheckIfFaceStateChanged()
    {
        if((_PA.characterEmotion).ToString() != prevFaceState)
        {
            //print("Prev: " + prevFaceState);
            //print("Current: " + _PA.characterEmotion.ToString());

            prevFaceState = _PA.characterEmotion.ToString();
            randomised = false;
            noisePlayed = false;
        }

    }

    IEnumerator NoiseCooldown()
    {
        noiseCoolDownBool = true;
        yield return new WaitForSeconds(noiseCooldownTime);
        noiseCoolDownBool = false;
    }
}
