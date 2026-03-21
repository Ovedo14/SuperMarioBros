using UnityEngine;

//Ricardo Oved Cornejo Castro A01803272

// Script que maneja el cambio de animaciones del personaje dependiendo de si se mueve y si esta en el suelo o no
public class ChangeAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CharacterState state;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        state = GetComponent<CharacterState>();
    }

    void Update()
    {
        if (animator == null || !animator.isActiveAndEnabled || animator.runtimeAnimatorController == null)
            return;

        float horizontalVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Velocity", horizontalVelocity);

       
        if (rb.linearVelocity.x > 0.1f)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x < -0.1f)
        {
            sr.flipX = false;
        }

        if (state != null)
        {
            animator.SetBool("IsGrounded", state.IsGrounded);
        }
    }
}
