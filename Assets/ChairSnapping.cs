using UnityEngine;

public class ChairSnapping : MonoBehaviour
{
    public Transform targetPosition; // The empty box where the chair should snap
    public GameObject congratulationsText; // The congratulations UI element or text object
    public float snapThreshold = 0.5f; // Distance threshold for snapping
    public float snapSpeed = 5f; // Speed of the snapping animation

    private bool isSnapping = false; // Whether the snapping process is active
    private bool snapped = false; // Whether the chair has snapped into position

    void Start()
    {
        // Ensure congratulations text is initially inactive
        if (congratulationsText != null)
        {
            congratulationsText.SetActive(false);
        }
    }

    void Update()
    {
        if (!snapped && Vector3.Distance(transform.position, targetPosition.position) <= snapThreshold)
        {
            isSnapping = true;
        }

        if (isSnapping && !snapped)
        {
            SnapToTarget();
        }
    }

    private void SnapToTarget()
    {
        // Smoothly move the chair towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, snapSpeed * Time.deltaTime);

        // Check if it has reached the target position
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
        {
            isSnapping = false;
            snapped = true;
            DisplayCongratulations();
        }
    }

    private void DisplayCongratulations()
    {
        if (congratulationsText != null)
        {
            congratulationsText.SetActive(true);
            Debug.Log("Congratulations! Chair snapped into position.");
        }
        else
        {
            Debug.LogWarning("Congratulations text object is not assigned.");
        }
    }
}
