using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    // Time in seconds before the object gets destroyed
    [SerializeField]
    private float destroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to destroy the object
        StartCoroutine(DestroyObject());
    }

    // Coroutine to destroy the object after a delay
    IEnumerator DestroyObject()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(destroyTime);

        // Destroy the GameObject
        Destroy(gameObject);
    }
}
