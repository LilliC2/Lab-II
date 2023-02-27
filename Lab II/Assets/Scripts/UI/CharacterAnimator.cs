using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterAnimator : Singleton<CharacterAnimator>
{
    Animator anim;
    public enum Face { reset, sad, smile, happy}
    
    public Face face;
    public Canvas canvas;

    public Image characterFace;

    public Sprite sad;
    public Sprite resetFace;
    public Sprite smile;
    public Sprite happy;

    public TMP_Text sadText;
    public TMP_Text smileText;
    public TMP_Text happyText;

    void Start()
    {
        anim = GetComponent<Animator>();
        sadText.enabled = false;
        smileText.enabled = false;
        happyText.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            PlayAnimation("Reset");
        if (Input.GetKeyDown(KeyCode.J))
            PlayAnimation("Sad");
        if (Input.GetKeyDown(KeyCode.K))
            PlayAnimation("Happy");
        if (Input.GetKeyDown(KeyCode.L))
            PlayAnimation("Happy");
        
        ChangeFace();

    }

    public void PlayAnimation(string _string)
    {
        anim.SetTrigger(_string);
    }

    public void ChangeFace()
    {
        switch(face)
        {
            case Face.reset:
                characterFace.sprite = resetFace;
                sadText.enabled = false;
                smileText.enabled = false;
                happyText.enabled = false;
                //PlayAnimation("Reset");
                //anim.ResetTrigger("Sad");
                //anim.ResetTrigger("Happy");
                //anim.ResetTrigger("Smile");
                break;
            case Face.sad:
                characterFace.sprite = sad;
                sadText.enabled = true;
                smileText.enabled = false;
                happyText.enabled = false;
                //PlayAnimation("Sad");
                //anim.ResetTrigger("Reset");
                //anim.ResetTrigger("Happy");
                //anim.ResetTrigger("Smile");
                break;
            case Face.smile:
                characterFace.sprite = smile;
                sadText.enabled = false;
                smileText.enabled = true;
                happyText.enabled = false;
                //PlayAnimation("Smile");
                //anim.ResetTrigger("Sad");
                //anim.ResetTrigger("Happy");
                //anim.ResetTrigger("Reset");
                break;
            case Face.happy:
                characterFace.sprite = happy;
                sadText.enabled = false;
                smileText.enabled = false;
                happyText.enabled = true;
                //PlayAnimation("Happy");
                //anim.ResetTrigger("Sad");
                //anim.ResetTrigger("Reset");
                //anim.ResetTrigger("Smile");
                break;
        }
    }

    public void EnablePanel()
    {
        canvas.enabled = true;
    }

    
}
