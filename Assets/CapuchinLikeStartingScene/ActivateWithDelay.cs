using UnityEngine;
using System.Collections;

public class ActivateWithDelay : MonoBehaviour
{
    public GameObject targetObject;  // Reference to the GameObject to enable
    public float delay = 5.0f;        // Time in seconds before enabling the GameObject

    private void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);  // Ensure the object is initially disabled
            StartCoroutine(ActivateObjectAfterDelay());
        }
        else
        {
            Debug.LogError("Target GameObject is not assigned.");
        }
    }

    private IEnumerator ActivateObjectAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(true);
    }
}
