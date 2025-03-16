using easyInputs;
using System.Collections;
using UnityEngine;
using TMPro;

public class TalkingDude : MonoBehaviour
{
    public TextMeshPro questText;
    public GameObject collectButton;
    public AudioSource talkingTalahonSound;
    public int neededBananas;
    public int foundBananas;
    public Animator guyTalkingStuff;
    public string animationBoolName;
    private bool isInZone;
    public EasyHand hand;
    public float talkingTime;
    public bool gotTriggerd;
    public bool isCollectReady;
    private string textToDisp;


    private void Start()
    {
        UpdateBananaText();
        collectButton.SetActive(true);
        foundBananas = PlayerPrefs.GetInt("CollectedBananas");
    }
    private void Update()
    {
        if (!isCollectReady)
        {
            if (foundBananas == neededBananas)
            {
                FinishedTheQuest();
            }
        }
        if (!gotTriggerd)
        {
            if (isInZone)
            {
                if (EasyInputs.GetTriggerButtonDown(hand))
                {
                    UpdateBananaText();
                    gotTriggerd = true;
                    guyTalkingStuff.SetBool(animationBoolName, true);
                    talkingTalahonSound.Play();
                    StartCoroutine(StopTalkingGuy());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInZone = false;
    }

    IEnumerator StopTalkingGuy()
    {
        yield return new WaitForSeconds(talkingTime);
        guyTalkingStuff.SetBool(animationBoolName, false);
    }

    public void SaveCurrentBananas()
    {
        PlayerPrefs.SetInt("CollectedBananas", foundBananas);
        PlayerPrefs.Save();
    }

    public void FoundBanana()
    {
        foundBananas += 1;
        UpdateBananaText();
    }

    public void FinishedTheQuest()
    {
        isCollectReady = true;
        collectButton.SetActive(true);
    }

    public void UpdateBananaText()
    {
        textToDisp = foundBananas.ToString() + (" from ") + neededBananas.ToString();
        questText.text = textToDisp.ToString();
    }
}
