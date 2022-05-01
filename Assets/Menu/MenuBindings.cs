using UnityEngine;
using UnityEngine.UIElements;

public class MenuBindings : MonoBehaviour
{
    private const string startButtonTreeHandle = "start";
    private const string settingsButtonTreeHandle = "settings";
    private const string exitButtonTreeHandle = "exit";
    private const string closeButtonTreeHandle = "close";
    private const string settingsBackButtonTreeHandle = "back";

    private UIDocument mainMenu;

    private VisualElement rootElement;
    private Button startButton;
    private Button settingsButton;
    private Button exitButton;
    private Button closeButton;
    private Button settingsBackButton;


    // Start is called before the first frame update
    private void Start()
    {
        mainMenu = GetComponent<UIDocument>();
        rootElement = mainMenu.rootVisualElement;

        MenuController.root = rootElement;

        startButton = rootElement.Q<Button>(startButtonTreeHandle);
        settingsButton = rootElement.Q<Button>(settingsButtonTreeHandle);
        exitButton = rootElement.Q<Button>(exitButtonTreeHandle);
        closeButton = rootElement.Q<Button>(closeButtonTreeHandle);
        settingsBackButton = rootElement.Q<Button>(settingsBackButtonTreeHandle);

        InitializeButtonMethods();
    }

    private void InitializeButtonMethods()
    {
        startButton.clickable.clicked += () => 
        {
            Debug.Log("Pressed Start");
            MenuController.StartGame();
        };
        settingsButton.clickable.clicked += () => 
        {
            Debug.Log("Pressed Settings");
            MenuController.OpenSettings();
        };
        exitButton.clickable.clicked += () => 
        {
            Debug.Log("Pressed Exit");
            MenuController.ExitGame();
        };
        closeButton.clickable.clicked += () =>
        {
            Debug.Log("Pressed Close");
            MenuController.CloseMenu();
        };

        settingsBackButton.clickable.clicked += () =>
        {
            Debug.Log("Pressed Back");
            MenuController.SettingsBack();
        };
    }
}
