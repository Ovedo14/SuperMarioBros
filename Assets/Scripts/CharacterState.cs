using UnityEngine;
using UnityEngine.SceneManagement;

//Ricardo Oved Cornejo Castro A01803272

// Script que maneja el estado del personaje, si esta en el suelo o no y si esta muerto o no

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
    /*Funcion que se ejecuta al morir el personaje, desactiva el movimiento, el collider y asigna una velocidad de 
     * salto para simular un rebote al morir, ademas de activar la animacion de muerte y cambiar a la escena del 
     * menu despues de 1.5 segundos*/

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