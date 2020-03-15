using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFaceController : MonoBehaviour
{
    public Emotion myEmotions;
    [SerializeField] private MisionController misionController;
    private Image image;
    private Animator animationControl;

    void Start()
    {
        animationControl = GetComponent<Animator>();
        image = GetComponent<Image>();
        misionController.OnPlayerMisionFinished += ChangeEmotion;
    }

    public void ChangeEmotion(TypeEmotion emo)
    {
        switch (emo)
        {
            case TypeEmotion.Basic:
                image.sprite = myEmotions.basicImage;
                break;

            case TypeEmotion.Sad:
                image.sprite = myEmotions.sadImage;
                animationControl.SetTrigger("Sad");
                Invoke("RestoreBasicImage", 0.9f);


                break;

            case TypeEmotion.Happy:
                image.sprite = myEmotions.happyImage;
                animationControl.SetTrigger("Happy");
                Invoke("RestoreBasicImage", 0.9f);

                break;
        }
    }

    private void RestoreBasicImage()
    {
        ChangeEmotion(TypeEmotion.Basic);
    }

}

[System.Serializable]
public struct Emotion
{
    public TypeEmotion emotionType;
    public Sprite basicImage;
    public Sprite sadImage;
    public Sprite happyImage;
}

public enum TypeEmotion
{
    Basic,
    Sad,
    Happy
}
