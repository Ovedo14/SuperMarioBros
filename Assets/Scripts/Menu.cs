using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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

    void PlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Game");
    }

    void ShowHelp(ClickEvent evt)
    {
        SceneManager.LoadScene("Help");
    }

    void ShowCredits(ClickEvent evt) {
        SceneManager.LoadScene("Credits");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
