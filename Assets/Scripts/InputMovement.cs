using UnityEngine;
using UnityEngine.InputSystem;

//Ricardo Oved Cornejo Castro A01803272

// Scritp que maneja el movimiento del personaje
public class InputMovement : MonoBehaviour
{
    //Variables para registrar las acciones de movimiento, salto y correr
    [SerializeField]
    private InputAction MovementeAction;

    [SerializeField]
    private InputAction JumpAction;

    [SerializeField]
    private InputAction RunAction;

    //Velocidades para el movimiento normal y corriendo ademas de rigibody y el estado del personaje

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

    //Funcion que se ejecuta al realizar la accion de salto, verifica si el personaje esta en el suelo y asigna la velocidad de salto dependiendo si esta corriendo o no
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