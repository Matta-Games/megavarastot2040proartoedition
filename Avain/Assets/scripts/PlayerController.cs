using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private float yVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveWithGamepad();
        MoveWithKeyboard();
        Attack();
        Jump();
    }
    void MoveWithGamepad()
    {
        if (Gamepad.current == null)
            return;

        Vector2 stickInput = Gamepad.current.leftStick.ReadValue();

        Vector3 move = new Vector3(stickInput.x, 0, stickInput.y);

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    void MoveWithKeyboard()
    {
        if (Keyboard.current == null)
            return;

        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            move.z += 1;

        if (Keyboard.current.sKey.isPressed)
            move.z -= 1;

        if (Keyboard.current.aKey.isPressed)
            move.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            move.x += 1;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    void Attack()
    {
        if (Gamepad.current == null)
            return;

        float triggerValue = Gamepad.current.rightTrigger.ReadValue();

        if (triggerValue > 0.5f)
        {
            Debug.Log("Hyökkäys aktivoitu");
        }
    }
    void Jump()
    {
        if (Gamepad.current != null &&
            Gamepad.current.buttonSouth.wasPressedThisFrame &&
            controller.isGrounded)
        {
            yVelocity = jumpForce;
        }

        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        yVelocity += gravity * Time.deltaTime;

        Vector3 verticalMove = new Vector3(0, yVelocity, 0);
        controller.Move(verticalMove * Time.deltaTime);
    }
}