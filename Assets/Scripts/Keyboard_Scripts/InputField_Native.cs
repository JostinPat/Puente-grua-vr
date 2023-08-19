using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InputField_Native : MonoBehaviour
{
    public TMP_InputField myField;
    public bool mayuscula;
    public int cursorPosition;


    private void Update()
    {

    }
    public void addLetter(string input) 
    {

        if (mayuscula)
        {
            input = input.ToUpper();
        }


        myField.text = myField.text.Insert(myField.caretPosition, input);
        myField.caretPosition = myField.text.Length;
    }

    public void deleteLeer() 
    {
        if(myField.text.Length > 0) 
        {
            myField.text = myField.text.Remove(myField.caretPosition - 1, 1);
            myField.caretPosition = myField.text.Length;
        }
    }

    public void setMayus() 
    {
        mayuscula = !mayuscula;
    }

    public void redirectField(TMP_InputField FieldToBeFocus) 
    {
        myField = FieldToBeFocus;
    }
}
