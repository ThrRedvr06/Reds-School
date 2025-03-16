using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshPro timeText;

    private void Update()
    {
        if (timeText != null)
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("MM/dd/yyyy HH:mm:ss");
            timeText.text = formattedTime;
        }
    }
}