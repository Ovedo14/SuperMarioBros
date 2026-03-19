using UnityEngine;

public class MarioCamera : MonoBehaviour
{
    public Transform mario;

    [Header("Velocidad")]
    public float suavizado = 0.15f;
    private Vector3 velocidadCamara = Vector3.zero;

    [Header("Límites del Mapa")]
    public float limiteIzquierdo = 0f;
    public float limiteDerecho = 100f;

    [Header("Zona Muerta")]
    public float margenHorizontal = 1f;

    void LateUpdate()
    {
        if (mario == null) return;

        float xCamara = transform.position.x;
        float xMario = mario.position.x;
        float targetX = xCamara;

        if (xMario > xCamara + margenHorizontal)
        {
            targetX = xMario - margenHorizontal;
        }
        else if (xMario < xCamara - margenHorizontal)
        {
            targetX = xMario + margenHorizontal;
        }

        targetX = Mathf.Clamp(targetX, limiteIzquierdo, limiteDerecho);

        Vector3 posicionObjetivo = new Vector3(targetX, transform.position.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, posicionObjetivo, ref velocidadCamara, suavizado);
    }
}