﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionController : MonoBehaviour
{
    public TurnsManager turnsManager;
    [SerializeField] private GameObject mision;
    [SerializeField] private AnimationUIController popUpWin;
    public event System.Action<TypeEmotion> OnPlayerMisionFinished;

    private void OnEnable()
    {
        turnsManager.OnPlayerSelected += DistributeMision;
        turnsManager.player1.OnArrived += CompareArrive;
        turnsManager.player2.OnArrived += CompareArrive;
    }
    
    private void DistributeMision( CharacterController playerArg)
    {
        Vector3 misionPos = playerArg.transform.position;

        misionPos.y = Random.Range(playerArg.limits.lowerY, playerArg.limits.upperY);
        misionPos.x = Random.Range(playerArg.limits.lowerX, playerArg.limits.upperX);
        mision.transform.position = misionPos;
    }

    private void CompareArrive(Vector3 playerPosit)
    {
        if (mision.transform.position == playerPosit)
        {
            popUpWin.ActiveAnimation();
            OnPlayerMisionFinished?.Invoke(TypeEmotion.Happy);
        }
        else
        {
            OnPlayerMisionFinished?.Invoke(TypeEmotion.Sad);
        }


    }
}

