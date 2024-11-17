using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToPoint : MonoBehaviour
{
    public float snapRange = 0.5f;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, snapRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("SnapPoint"))
            {
                transform.position = collider.transform.position; // Snap to the snap point
                break;
            }
        }
    }
}
