using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public bool IsGrounded { get; private set; } = false;
    public bool IsDead { get; private set; } = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    public void Die()
    {
        IsDead = true;
    }
}