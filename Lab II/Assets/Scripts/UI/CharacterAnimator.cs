using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : Singleton<CharacterAnimator>
{
    Animator anim;
    public enum Face { reset, sad, smile, happy}
    
    public Face face;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            PlayAnimation("Reset");
        if (Input.GetKeyDown(KeyCode.J))
            PlayAnimation("Reset");
        if (Input.GetKeyDown(KeyCode.K))
            PlayAnimation("Reset");
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
                PlayAnimation("Reset");
                break;
            case Face.sad:
                PlayAnimation("Reset");
                break;
            case Face.smile:
                PlayAnimation("Reset");
                break;
            case Face.happy:
                PlayAnimation("Happy");
                break;
        }
    }

    
}
