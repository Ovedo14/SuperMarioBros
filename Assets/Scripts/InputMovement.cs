using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{
    [SerializeField]
    private InputAction MovementeAction;

    [SerializeField]
    private InputAction JumpAction;

    private float XVelocity = 7f;
    private float YVelocity = 7f;

    private Rigidbody2D Rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MovementeAction.Enable();
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        JumpAction.Enable();
        JumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        JumpAction.Disable();
        JumpAction.performed -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Rb.linearVelocityY = YVelocity * 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = MovementeAction.ReadValue<Vector2>();

        Rb.linearVelocityX = movement.x * XVelocity;

    }
}
