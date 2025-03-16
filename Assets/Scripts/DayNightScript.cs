using System.Collections;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [Header("This is BloodymoonVR's, so please give credit!")]

    public GameObject objectEnable;
    public GameObject objectDisable;

    public float interval = 5f;
    public Material daySkybox;
    public Material nightSkybox;

    private bool isEnabled = true;

    void Start()
    {
        StartCoroutine(ToggleObjectsAndSkybox());
    }

    IEnumerator ToggleObjectsAndSkybox()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            if (isEnabled)
            {
                objectEnable.SetActive(false);
                objectDisable.SetActive(true);
                RenderSettings.skybox = nightSkybox;
            }
            else
            {
                objectEnable.SetActive(true);
                objectDisable.SetActive(false);
                RenderSettings.skybox = daySkybox;
            }

            isEnabled = !isEnabled;
        }
    }
}
