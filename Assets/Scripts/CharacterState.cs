using UnityEngine;

public class CharacterState : MonoBehaviour
{

    public bool IsGrounded { get; private set; } = false;
    public bool direction { get; private set; } = false;
    public bool IsDead { get; private set;} = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
