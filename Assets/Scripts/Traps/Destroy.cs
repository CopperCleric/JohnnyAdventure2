using UnityEngine;
using System.Collections;

public class FallingTile : MonoBehaviour
{
    private bool isCharacterOnTile = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCharacterOnTile)
        {
            Debug.Log("Player detected on tile.");
            isCharacterOnTile = true;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        Debug.Log("Starting coroutine to destroy tile.");
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Destroy the tile GameObject
        Debug.Log("Destroying tile.");
        Destroy(gameObject);
    }
}
