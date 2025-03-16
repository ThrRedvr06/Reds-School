using UnityEngine;
using System.Collections;

public class DeactivateWithDelay : MonoBehaviour
{
    public GameObject targetObject;  // Reference to the GameObject to disable
    public float duration = 5.0f;     // Time in seconds before disabling the GameObject

    private void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);  // Ensure the object is initially enabled
            StartCoroutine(DeactivateObjectAfterDuration());
        }
        else
        {
            Debug.LogError("Target GameObject is not assigned.");
        }
    }

    private IEnumerator DeactivateObjectAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        targetObject.SetActive(false);
    }
}
