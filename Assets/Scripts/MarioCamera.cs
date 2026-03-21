using UnityEngine;

//Ricardo Oved Cornejo Castro A01803272

/* Script que maneja el movimiento de la camara, hace que la camara siga al personaje pero con un margen de 
 * movimiento para evitar movimientos bruscos y ademas limita el movimiento de la camara a los limites del mapa*/

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
    /* Zona muerta es el margen horizontal que se le asigna a la camara, esto hace que la camara no se mueva hasta
     * que el personaje se salga de ese margen, esto evita movimientos bruscos de la camara y hace que el movimiento
     * sea mas fluido*/
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