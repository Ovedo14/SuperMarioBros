using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

//Ricardo Oved Cornejo Castro A01803272

// Script que maneja el menu principal, asigna las funciones a los botones del menu para cambiar de escena al hacer click en ellos

public class Menu : MonoBehaviour
{
    private UIDocument menu;
    private Button playButton;
    private Button helpButton;
    private Button creditsButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;
        playButton = root.Q<Button>("PlayButton");
        helpButton = root.Q<Button>("HelpButton");
        creditsButton = root.Q<Button>("CreditsButton");
        playButton.RegisterCallback<ClickEvent>(PlayGame);
        helpButton.RegisterCallback<ClickEvent>(ShowHelp);
        creditsButton.RegisterCallback<ClickEvent>(ShowCredits);
    }

    void OnDisable()
    {
        playButton.UnregisterCallback<ClickEvent>(PlayGame);
        helpButton.UnregisterCallback<ClickEvent>(ShowHelp);
        creditsButton.UnregisterCallback<ClickEvent>(ShowCredits);
    }
    //Funciones que se ejecutan al hacer click en los botones del menu, cambian a la escena correspondiente
    void PlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Game");
    }
    //Funcion que se ejecuta al hacer click en el boton de ayuda, cambia a la escena de ayuda
    void ShowHelp(ClickEvent evt)
    {
        SceneManager.LoadScene("Help");
    }
    //Funcion que se ejecuta al hacer click en el boton de creditos, cambia a la escena de creditos
    void ShowCredits(ClickEvent evt) {
        SceneManager.LoadScene("Credits");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
