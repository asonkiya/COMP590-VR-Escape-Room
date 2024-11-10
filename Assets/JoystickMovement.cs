using UnityEngine;
using UnityEngine.XR;

public class JoystickMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get joystick input
        Vector2 inputAxis;
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand); // Assuming left joystick for movement
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);
            direction = transform.TransformDirection(direction); // Convert local to world space

            // Apply movement
            characterController.Move(direction * speed * Time.deltaTime);
        }
    }
}
