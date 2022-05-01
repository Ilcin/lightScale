using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera mainCamera;
    public float speed = 2f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = mainCamera.transform.position;

        position.y = Mathf.Lerp(mainCamera.transform.position.y, transform.position.y, interpolation);
        position.x = Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, interpolation);

        mainCamera.transform.position = position;
    }

}
