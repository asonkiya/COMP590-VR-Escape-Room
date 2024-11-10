using UnityEngine;
using UnityEngine.XR;

public class JoystickMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private CharacterController characterController;
    private Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform; // Get the Main Camera's transform
    }

    void Update()
    {
        // Get joystick input
        Vector2 inputAxis;
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand); // Assuming left joystick for movement
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            // Calculate movement direction based on the camera's forward and right directions
            Vector3 direction = cameraTransform.forward * inputAxis.y + cameraTransform.right * inputAxis.x;
            direction.y = 0; // Keep movement horizontal

            // Apply movement
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
