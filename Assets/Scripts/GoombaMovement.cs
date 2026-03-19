using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public float velocidad = 2f;
    private int direccion = -1;

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterState player = collision.GetComponent<CharacterState>();

            if (player != null)
            {
                player.Die();
            }
            return;
        }
        if (collision.CompareTag("Ground") || collision.gameObject.name == "InvisibleWall")
        {
            direccion *= -1;
        }
    }
}