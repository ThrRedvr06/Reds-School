using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddNumber : MonoBehaviour
{
    [Header("Credits: TheCoder")]
    
    [Header("TMP Object")]
    public TMP_Text PasswordDisplay;
    
    [Header("Number to add")]
    public string Number;
    
    [Header("Max Numbers")]
    public int max = 4;
    
    [Header("Hand/Finger Tag")]
    public string Tag;
    
    private bool canType = true;
    
    private void OnTriggerEnter(Collider other)
    {
        int totalCharacters = PasswordDisplay.textInfo.characterCount;
        
        if (other.gameObject.CompareTag(Tag))
        {
            if (totalCharacters < max)
            {
                PasswordDisplay.text += Number;
            }
        }
    }
}
