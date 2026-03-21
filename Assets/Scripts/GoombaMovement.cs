using UnityEngine;

//Ricardo Oved Cornejo Castro A01803272

// Script que maneja el movimiento del goomba, hace que el goomba se mueva de un lado a otro y que el personaje muera al colisionar con el goomba
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