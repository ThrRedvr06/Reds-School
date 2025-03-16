using UnityEngine;
using TMPro;

public class PasswordManager : MonoBehaviour
{
    [Header("Credits: TheCoder")]

    [Header("TMP Object")]
    public TMP_Text PasswordDisplay;

    [Header("Password")]
    public string Password = "1234";
    
    [Header("Max Numbers")]
    [Header("MAKE SURE MAX LENGTH AS YOUR SET PASSWORD!")]
    public int max = 4;

    [Header("Objects to enable or disable")]
    public GameObject[] Enable;
    public GameObject[] Disable;

    [Header("Info Display")]
    public GameObject WrongPass;
    public GameObject CorrectPass;
    public GameObject MoreNeeded;
    
    [Header("Hand/Finger Tag")]
    public string Tag;
 
    private string Clear = "";

    private void OnTriggerEnter(Collider other)
    {
        int totalCharacters = PasswordDisplay.textInfo.characterCount;
        
        if (other.gameObject.CompareTag(Tag))
        {
          if (totalCharacters == max)
          {
              
            if (PasswordDisplay.text == Password)
            {
                CorrectPass.SetActive(true);
                WrongPass.SetActive(false);
                PasswordDisplay.text = Clear;
                MoreNeeded.SetActive(false);
                
                foreach (GameObject objEnable in Enable)
                {
                    objEnable.SetActive(true);
                }
                
                foreach (GameObject objDisable in Disable)
                {
                    objDisable.SetActive(false);
                }
            }
            else
            {
                WrongPass.SetActive(true);
                PasswordDisplay.text = Clear;
                MoreNeeded.SetActive(false);
            }
          } else if (totalCharacters < max)
          {
            MoreNeeded.SetActive(true);
          }
        }
    }
}
