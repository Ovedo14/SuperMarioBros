using UnityEngine;
using UnityEngine.SceneManagement;

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
        GetComponent<InputMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.linearVelocityY = 12f;
        GetComponent<Animator>().SetTrigger("IsDied");
        Invoke("CambiarEscena", 1.5f);
    }
    private void CambiarEscena()
    {
        SceneManager.LoadScene("Menu");
    }
}