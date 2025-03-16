using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCyclerTMP : MonoBehaviour
{
    public TMP_Text tmpText;
    public List<string> texts = new List<string>();
    public float cycleSpeed = 1f;

    private int currentIndex = 0;

    void Start()
    {
        if (texts.Count > 0)
        {
            StartCoroutine(CycleText());
        }
        else
        {
            Debug.LogWarning("Text list is empty. Add some texts to cycle through.");
        }
    }

    IEnumerator CycleText()
    {
        while (true)
        {
            tmpText.text = texts[currentIndex];
            currentIndex = (currentIndex + 1) % texts.Count;
            yield return new WaitForSeconds(cycleSpeed);
        }
    }
}
