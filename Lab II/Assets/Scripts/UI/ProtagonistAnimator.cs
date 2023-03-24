using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtagonistAnimator : Singleton<ProtagonistAnimator>
{
    Animator anim;
    public enum CharacterEmotion { Enter, Idle, Far, Medium, Close, Correct, Wrong, Right, Left, Spin, Reset }

    public CharacterEmotion characterEmotion;
    public Canvas canvas;

    public Image characterFace;

    public TMP_Text textBox;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterEmotion = CharacterEmotion.Enter;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            characterEmotion = CharacterEmotion.Far;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            characterEmotion = CharacterEmotion.Medium;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            characterEmotion = CharacterEmotion.Close;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            characterEmotion = CharacterEmotion.Correct;

        if (Input.GetKeyDown(KeyCode.Alpha5))
            characterEmotion = CharacterEmotion.Wrong;

        if (Input.GetKeyDown(KeyCode.Alpha6))
            characterEmotion = CharacterEmotion.Right;

        if (Input.GetKeyDown(KeyCode.Alpha7))
            characterEmotion = CharacterEmotion.Left;

        if (Input.GetKeyDown(KeyCode.Alpha8))
            characterEmotion = CharacterEmotion.Spin;

        if (Input.GetKeyDown(KeyCode.Alpha9))
            characterEmotion = CharacterEmotion.Idle;

        if (Input.GetKeyDown(KeyCode.Alpha0))
            characterEmotion = CharacterEmotion.Reset;

        ProtagonistAnim();

        //ChangeFace();

    }

    public void PlayAnimation(string _string)
    {
        anim.SetTrigger(_string);
    }

    public void ProtagonistAnim()
    {
        switch (characterEmotion)
        {
            case CharacterEmotion.Enter:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "";
                break;

            case CharacterEmotion.Idle:
                anim.SetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "...";
                break;

            case CharacterEmotion.Far:
                anim.ResetTrigger("Idle");
                anim.SetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "Too far...";
                break;

            case CharacterEmotion.Medium:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.SetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "Almost";
                break;

            case CharacterEmotion.Close:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.SetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "You're close!";
                break;

            case CharacterEmotion.Correct:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.SetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "Thats it, good job!";
                break;

            case CharacterEmotion.Wrong:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.SetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "I dont think it's supposed to be there";
                break;

            case CharacterEmotion.Right:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.SetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "Needs a right spin";
                break;

            case CharacterEmotion.Left:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.SetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "A little spin to the left";
                break;

            case CharacterEmotion.Spin:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.SetTrigger("Spin");
                anim.ResetTrigger("Reset");
                textBox.text = "Not the right angle here";
                break;

            case CharacterEmotion.Reset:
                anim.ResetTrigger("Idle");
                anim.ResetTrigger("Far");
                anim.ResetTrigger("Medium");
                anim.ResetTrigger("Close");
                anim.ResetTrigger("Correct");
                anim.ResetTrigger("Wrong");
                anim.ResetTrigger("Right");
                anim.ResetTrigger("Left");
                anim.ResetTrigger("Spin");
                anim.SetTrigger("Reset");
                textBox.text = "";
                break;
        }
    }

    //public void ChangeFace()
    //{
    //    switch (face)
    //    {
    //        case Face.reset:
    //            characterFace.sprite = resetFace;
    //            sadText.enabled = false;
    //            smileText.enabled = false;
    //            happyText.enabled = false;
    //            PlayAnimation("Reset");
    //            anim.ResetTrigger("Sad");
    //            anim.ResetTrigger("Happy");
    //            anim.ResetTrigger("Smile");
    //            break;
    //        case Face.sad:
    //            characterFace.sprite = sad;
    //            sadText.enabled = true;
    //            smileText.enabled = false;
    //            happyText.enabled = false;
    //            PlayAnimation("Sad");
    //            anim.ResetTrigger("Reset");
    //            anim.ResetTrigger("Happy");
    //            anim.ResetTrigger("Smile");
    //            break;
    //        case Face.smile:
    //            characterFace.sprite = smile;
    //            sadText.enabled = false;
    //            smileText.enabled = true;
    //            happyText.enabled = false;
    //            PlayAnimation("Smile");
    //            anim.ResetTrigger("Sad");
    //            anim.ResetTrigger("Happy");
    //            anim.ResetTrigger("Reset");
    //            break;
    //        case Face.happy:
    //            characterFace.sprite = happy;
    //            sadText.enabled = false;
    //            smileText.enabled = false;
    //            happyText.enabled = true;
    //            PlayAnimation("Happy");
    //            anim.ResetTrigger("Sad");
    //            anim.ResetTrigger("Reset");
    //            anim.ResetTrigger("Smile");
    //            break;
    //    }
    //}

    public void EnablePanel()
    {
        canvas.enabled = true;
    }
}
