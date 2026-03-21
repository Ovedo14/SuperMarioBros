using UnityEngine;

 //Ricardo Oved Cornejo Castro A01803272
 // Script que maneja la colision de la cabeza del goomba con el personaje, asigna la animacion de muerte y el rebote del personaje
 

public class GoombaHead : MonoBehaviour
{
    [Header("Ajustes")]
    public float fuerzaRebote = 7f;
    public float tiempoAnimacion = 0.5f;

    private Animator anim;
    private Rigidbody2D rbMario;

    public void Start()
    {
        rbMario = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    //Funcion que calcula las collisiones entre la cabeza del goomba y el personaje jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (rbMario != null && rbMario.linearVelocityY <= 0.1f)
            {
                rbMario.linearVelocity = new Vector2(rbMario.linearVelocity.x, fuerzaRebote);
                anim = GetComponentInParent<Animator>();
                if (anim != null) anim.SetTrigger("die");
                GoombaMovement movimiento = GetComponentInParent<GoombaMovement>();
                if (movimiento != null) movimiento.enabled = false;
                Collider2D colliderPadre = GetComponentInParent<Collider2D>();
                if (colliderPadre != null) colliderPadre.enabled = false;
                Destroy(transform.parent.gameObject, tiempoAnimacion);
            }
        }
    }
}