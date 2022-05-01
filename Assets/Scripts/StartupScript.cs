using UnityEngine;
using UnityEngine.InputSystem;

public class StartupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            MenuController.NavigateTo(MenuPage.Main);
        }
    }
}
