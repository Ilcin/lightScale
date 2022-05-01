using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UserTouchLight : MonoBehaviour
{
    public GameObject lightPrefab;

    private GameObject instantiatedLight;
    private Mouse mouse;
    private Touchscreen touchscreen;

    private void Start()
    {
        mouse = Mouse.current;
        touchscreen = Touchscreen.current;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (mouse.leftButton.isPressed)
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                InstantiateLightPrefab();
            }
            UpdateLightPosition();
        }
        if (mouse.leftButton.wasReleasedThisFrame)
        {
            DeleteInstantiatedLightPrefab();
        }
#elif UNITY_ANDROID
        if (touchscreen.primaryTouch.IsPressed)
        {
            Debug.Log("IPRESS");
        }
#endif
    }

    private void InstantiateLightPrefab()
    {
        instantiatedLight = Instantiate(lightPrefab);
        var light = instantiatedLight.GetComponent<LightObject>();
        light.SetValues();
    }

    private void DeleteInstantiatedLightPrefab()
    {
        Destroy(instantiatedLight);
    }

    private void UpdateLightPosition()
    {
        if (instantiatedLight != null)
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            instantiatedLight.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
    }
}
