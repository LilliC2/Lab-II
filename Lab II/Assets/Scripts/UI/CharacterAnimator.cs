using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : Singleton<CharacterAnimator>
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            PlayAnimation("Reset");
        if (Input.GetKeyDown(KeyCode.J))
            PlayAnimation("Sad");
        if (Input.GetKeyDown(KeyCode.K))
            PlayAnimation("Smile");
        if (Input.GetKeyDown(KeyCode.L))
            PlayAnimation("Happy");

    }

    public void PlayAnimation(string _string)
    {
        anim.SetTrigger(_string);
    }

    
}
