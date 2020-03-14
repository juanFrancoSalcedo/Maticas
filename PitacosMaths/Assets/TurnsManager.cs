using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private Timer timer;
    [SerializeField] private InputFieldController inputContol;
    public CharacterController player1;
    public  CharacterController player2;
    public event System.Action<CharacterController> OnPlayerSelected;

    private float bufferTime;

    private void Start()
    {
        bufferTime = timer.initTime;
        inputContol.currentChar = player1;
        OnPlayerSelected?.Invoke(inputContol.currentChar);
    }

    private void OnEnable()
    {
        player1.OnArrived += SwitchPlayer;
        player2.OnArrived += SwitchPlayer;
        timer.OnCalculatedTimeString += ShowTime;
    }

    private void SwitchPlayer(Vector3 arg)
    {
        inputContol.currentChar.gameObject.SetActive(false);

        if (ReferenceEquals(inputContol.currentChar, player1))
        {
            inputContol.currentChar = player2;
        }
        else
        {
            inputContol.currentChar = player1;
        }

        inputContol.currentChar.gameObject.SetActive(true);
        inputContol.ActiveButtons(true);
        inputContol.xInputField.text = "0";
        inputContol.yInputField.text = "0";
        OnPlayerSelected?.Invoke(inputContol.currentChar);
    }

    private void ShowTime(string timerString, float timeArg)
    {
        textTimer.text = timerString;

        if (timeArg <0)
        {
            timer.stopTimer = true ;
        }

    }
}

