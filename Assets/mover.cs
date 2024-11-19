using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float speedUpModifier = 1f;

    [SerializeField]
    private float speedDownModifier = 1f;

    [SerializeField]
    private InputAction up = new InputAction(type: InputActionType.Button);

    [SerializeField]
    private InputAction down = new InputAction(type: InputActionType.Button);

    [SerializeField]
    private InputAction left = new InputAction(type: InputActionType.Button);

    [SerializeField]
    private InputAction right = new InputAction(type: InputActionType.Button);

    [SerializeField]
    private InputAction speedUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    private InputAction speedDown = new InputAction(type: InputActionType.Button);

    private void OnEnable()
    {
        //Enable all actions
        up.Enable();
        down.Enable();
        left.Enable();
        right.Enable();
        speedUp.Enable();
        speedDown.Enable();
    }

    private void OnDisable()
    {
        //Disable all actions
        up.Disable();
        down.Disable();
        left.Disable();
        right.Disable();
        speedUp.Disable();
        speedDown.Disable();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (up.IsPressed()) movement += Vector3.up;
        if (down.IsPressed()) movement += Vector3.down;
        if (left.IsPressed()) movement += Vector3.left;
        if (right.IsPressed()) movement += Vector3.right;

        //modifying speed in case the player wants to slow down or speed up
        float newSpeed = speed;
        if (speedUp.IsPressed())
        {
            newSpeed *= speedUpModifier;
        }
        if (speedDown.IsPressed())
        {
            newSpeed *= speedDownModifier;
        }

        if (movement != Vector3.zero)
        {
            movement.Normalize();
        }

        transform.position += movement * newSpeed * Time.deltaTime;
    }
}