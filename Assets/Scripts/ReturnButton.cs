using UnityEngine;
using UnityEngine.UIElements;

public class ReturnButton : MonoBehaviour
{
    private UIDocument UIButton;
    private Button returnbutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    void OnEnable()
    {
        UIButton = GetComponent<UIDocument>();
        var root = UIButton.rootVisualElement;
        returnbutton = root.Q<Button>("ReturnButton");
        returnbutton.RegisterCallback<ClickEvent>(ReturnToMenu);
    }
    void OnDisable()
    {
        returnbutton.UnregisterCallback<ClickEvent>(ReturnToMenu);
    }
    void ReturnToMenu(ClickEvent evt)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
