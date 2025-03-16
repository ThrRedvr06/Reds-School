using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiChecker : MonoBehaviour
{
    [Header("Off")]
    public GameObject WifiOff;
    [Header("On")]
    public GameObject WifiOn;

    void Update()
    {
         if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            WifiOff.SetActive(true);
            WifiOn.SetActive(false);
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            WifiOn.SetActive(true);
            WifiOff.SetActive(false);
        }
    }
}
