using UnityEngine;

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

        if (state != null && state.IsDead)
        {
            animator.SetTrigger("Die");
        }
    }
}
