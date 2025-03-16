using UnityEngine;
using TMPro;

public class DisplayLocalTime : MonoBehaviour
{
    [Header("Made by Vnxz do not steal.")]
    [SerializeField] private TextMeshPro timeText;

    private void Update()
    {
        string currentTime = System.DateTime.Now.ToString("hh:mm tt");
        timeText.text = "Local Time: " + currentTime;
    }
}
