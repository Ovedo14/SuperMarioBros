using UnityEngine;

public class ChangeAniimation : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CharacterState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        state = GetComponent<CharacterState>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rb.linearVelocity.x));
        sr.flipX = rb.linearVelocity.x < 0;

        animator.SetBool("IsGrounded", state.IsGrounded);
    }
}
