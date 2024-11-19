using UnityEngine;

public class ChairPositionScript : MonoBehaviour
{
    public GameObject congratulationsText;
    public float displayDuration = 3f;
    public GameObject explosionEffect; // Assign your particle effect prefab here

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CorrectChair"))
        {
            // Display congratulations text
            if (congratulationsText != null)
            {
                congratulationsText.SetActive(true);
                Invoke("HideCongratulationsText", displayDuration);
            }
            else
            {
                Debug.LogWarning("Congratulations text object is not assigned.");
            }

            // Show explosion effect
            ShowExplosionEffect(collision.contacts[0].point);
        }
    }

    private void HideCongratulationsText()
    {
        if (congratulationsText != null)
        {
            congratulationsText.SetActive(false);
        }
    }

    private void ShowExplosionEffect(Vector3 position)
    {
        if (explosionEffect != null)
        {
            // Instantiate the particle effect at the collision point
            Instantiate(explosionEffect, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Explosion effect prefab is not assigned.");
        }
    }
}
