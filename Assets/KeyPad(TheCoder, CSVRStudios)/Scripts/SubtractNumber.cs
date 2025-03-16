 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtractNumber : MonoBehaviour
{
    [Header("Credits: TheCoder")]
    
    [Header("TMP Object")]
    public TMP_Text PasswordDisplay;
    
    [Header("Hand/Finger Tag")]
    public string Tag;
    
    private bool canSub = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            int totalCharacters = PasswordDisplay.textInfo.characterCount;
            
            if (totalCharacters > 0)
            {
                PasswordDisplay.text = PasswordDisplay.text.Remove(PasswordDisplay.text.Length - 1);
            }
        }
    }
}
