using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DentedPixel;

public class AnimationController : MonoBehaviour
{
    private RectTransform rectTransform;
    public Vector3 targetPosition;
    private Vector3 originPosition;
    public float timeAnimation;
    public float delay;
    public float coldTime;
    public AnimationCurve animationCurve;
    public bool playOnAwake;
    public TypeAnimation animationType;

    public enum TypeAnimation
    {
        Move,
        MoveReturnOrigin
    }

    public UnityEvent OnCompletedCallBack;
    public event System.Action OnCompleted;
    

    private void OnEnable()
    {
        originPosition = transform.localPosition;
        OnCompleted += CallBacks;
        
        if (playOnAwake)
        {
            ActiveAnimation();
        }
    }
    
    public void ActiveAnimation()
    {
        var sequence = LeanTween.sequence();


        switch (animationType)
        {
            case TypeAnimation.Move:
                LeanTween.move(gameObject, targetPosition, timeAnimation).setEase(animationCurve).setDelay(delay).setOnComplete(CallBacks);
                break;

            case TypeAnimation.MoveReturnOrigin:
                sequence.append(LeanTween.moveLocal(gameObject, targetPosition, timeAnimation).setEase(animationCurve).setDelay(delay));
                sequence.append(coldTime); 
                sequence.append(LeanTween.moveLocal(gameObject, originPosition, timeAnimation).setEase(animationCurve).setOnComplete(CallBacks));
                break;
        }
    }


    private void CallBacks()
    {
        OnCompletedCallBack?.Invoke();
    }
    

    public void SetColdTime(float _time)
    {
        coldTime = _time;
    }
}
