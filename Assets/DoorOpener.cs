using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform door; // Assign your door GameObject here
    public float rotationAngle = 90f; // Degrees to rotate
    public float rotationSpeed = 2f; // Speed of rotation

    private bool isDoorOpen = false;

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            StartCoroutine(RotateDoor());
            isDoorOpen = true;
        }
    }

    private System.Collections.IEnumerator RotateDoor()
    {
        Quaternion targetRotation = Quaternion.Euler(0, rotationAngle, 0) * door.rotation;
        while (Quaternion.Angle(door.rotation, targetRotation) > 0.1f)
        {
            door.rotation = Quaternion.Slerp(door.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }
        door.rotation = targetRotation;
    }
}
