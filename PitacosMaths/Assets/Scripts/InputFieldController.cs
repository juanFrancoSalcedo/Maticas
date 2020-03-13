using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField xInputField;
    [SerializeField] private TMP_InputField yInputField;
    [SerializeField] private Button startPathButton;

    [SerializeField] private GridManger grid;
    [SerializeField] private CharacterController character;
    
    void Start()
    {
        startPathButton.onClick.AddListener(StartPath);
    }


    public void StartPath()
    {
        int xCordinate =  (xInputField.text.Equals("")) ? 0 : int.Parse(xInputField.text);
        int yCordinate =  (yInputField.text.Equals("")) ? 0 : int.Parse(yInputField.text);

        grid.targetX = xCordinate;
        grid.targetY = yCordinate;

        character.StartCoroutine(character.Move());

        startPathButton.gameObject.SetActive(false);
        xInputField.gameObject.SetActive(false);
        yInputField.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }
}
