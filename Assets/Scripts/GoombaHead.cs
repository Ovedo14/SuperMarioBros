using UnityEngine;

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