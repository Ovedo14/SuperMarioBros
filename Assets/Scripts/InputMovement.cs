using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{
    [SerializeField]
    private InputAction MovementeAction;

    [SerializeField]
    private InputAction JumpAction;

    [SerializeField]
    private InputAction RunAction;

    private float normalXVelocity = 7f;
    private float normalYVelocity = 12f;

    private float runXVelocity = 9f;
    private float runYVelocity = 15f;

    private Rigidbody2D Rb;
    private CharacterState state;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        state = GetComponentInChildren<CharacterState>();
    }

    private void OnEnable()
    {
        MovementeAction.Enable();
        JumpAction.Enable();
        RunAction.Enable();

        JumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        JumpAction.Disable();
        MovementeAction.Disable();
        RunAction.Disable();

        JumpAction.performed -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (state.IsGrounded)
        {
            if (RunAction.IsPressed())
            {
                Rb.linearVelocityY = runYVelocity;
            }
            else
            {
                Rb.linearVelocityY = normalYVelocity;
            }
        }
    }

    void Update()
    {
        Vector2 movement = MovementeAction.ReadValue<Vector2>();
        float currentXVelocity = normalXVelocity;

        if (RunAction.IsPressed())
        {
            currentXVelocity = runXVelocity;
        }
        Rb.linearVelocityX = movement.x * currentXVelocity;
    }
}