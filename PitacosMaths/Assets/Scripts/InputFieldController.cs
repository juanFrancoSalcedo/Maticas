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
    public CharacterController currentChar;

    [SerializeField] private GridManger grid;
    [SerializeField] private CharacterController character;

    void Start()
    {
      //  xInputField.text = ""+0 ;
     //   yInputField.text = ""+0 ;

     //   InsertCoordinates();

        startPathButton.onClick.AddListener(StartPath);
        startPathButton.onClick.AddListener(InsertCoordinates);

        xInputField.onEndEdit.AddListener(InsertCoordinates);
        yInputField.onEndEdit.AddListener(InsertCoordinates);


    }

    private void InsertCoordinates()
    {
        int xCoordinate = 0;
        int yCoordinate = 0;

        xCoordinate = (xInputField.text.Equals("")) ? 0 : int.Parse(xInputField.text);
        yCoordinate = (yInputField.text.Equals("")) ? 0 : int.Parse(yInputField.text);
        
        currentChar.targetX = XLimitTargets(xCoordinate);
        currentChar.targetY = YLimitTargets(yCoordinate);


  //      xInputField.text = "" + XLimitTargets(xCoordinate);
    //    yInputField.text = "" + YLimitTargets(yCoordinate);
    }

    private void InsertCoordinates(string valueNull)
    {
        int xCoordinate = 0;
        int yCoordinate = 0;
        
        xCoordinate = (xInputField.text.Equals("")) ? 0 : int.Parse(xInputField.text);
        yCoordinate = (yInputField.text.Equals("")) ? 0 : int.Parse(yInputField.text);

        currentChar.targetX = XLimitTargets(xCoordinate);
        currentChar.targetY = YLimitTargets(yCoordinate);

    }

    public void StartPath()
    {
        character.StartCoroutine(character.Move());

        startPathButton.gameObject.SetActive(false);
        xInputField.gameObject.SetActive(false);
        yInputField.gameObject.SetActive(false);
    }

    public int XLimitTargets(int coordinate)
    {
        if (coordinate <= currentChar.limits.lowerX)
        {
            return currentChar.limits.lowerX;
        }

        if (coordinate >= currentChar.limits.upperX)
        {
            return currentChar.limits.upperX;
        }
        return coordinate;
    }

    public int YLimitTargets(int coordinate)
    {
        if (coordinate<= currentChar.limits.lowerY)
        {
            return currentChar.limits.lowerY;
        }

        if (coordinate >= currentChar.limits.upperY)
        {
            return currentChar.limits.upperY;
        }

        return coordinate;
    }

}
