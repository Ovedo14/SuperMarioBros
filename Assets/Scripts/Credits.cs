using UnityEngine;
using UnityEngine.UIElements;

//Ricardo Oved Cornejo Castro A01803272

// Script que maneja el movimiento de los creditos en la escena de creditos, hace que los creditos se muevan y se repitan
public class Credits : MonoBehaviour
{
    [Header("Ajustes del Movimiento")]
    public float velocidad = 50f;
    public float inicioY = 300f;
    public float reinicioY = -600f;

    private Label textoCreditos;
    private float posicionY;

    void OnEnable()
    {
        var uiDoc = GetComponent<UIDocument>();
        textoCreditos = uiDoc.rootVisualElement.Q<Label>("CreditsText");

        if (textoCreditos != null)
        {
            posicionY = inicioY;
        }
    }

    void Update()
    {
        if (textoCreditos == null) return;
        posicionY -= velocidad * Time.deltaTime;
        if (posicionY <= reinicioY)
        {
            posicionY = inicioY;
        }
        textoCreditos.style.top = new StyleLength(posicionY);
    }
}