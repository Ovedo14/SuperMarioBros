using UnityEngine;

public class GoombaSensores : MonoBehaviour
{
    public float velocidad = 2f;
    private int direccion = -1;

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.gameObject.name == "InvisibleWall")
        {
            direccion *= -1;
        }
    }
}