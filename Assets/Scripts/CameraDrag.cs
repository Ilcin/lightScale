//using UnityEngine;

//public class CameraDrag : MonoBehaviour
//{
//    private Vector3 hit_position = Vector3.zero;
//    private Vector3 current_position = Vector3.zero;
//    private Vector3 camera_position = Vector3.zero;
//    private Camera main;
//    private const float scrollspeed = 10f;

//    // Use this for initialization
//    private void Start()
//    {
//        main = Camera.main;
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            hit_position = Input.mousePosition;
//            camera_position = transform.position;

//        }
//        if (Input.GetMouseButton(0))
//        {
//            current_position = Input.mousePosition;
//            LeftMouseDrag();
//        }
//        //zoom 
//        main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollspeed;
//    }

//    private void LeftMouseDrag()
//    {
//        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
//        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
//        current_position.z = hit_position.z = camera_position.y;

//        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
//        // anyways.  
//        Vector3 direction = main.ScreenToWorldPoint(current_position) - main.ScreenToWorldPoint(hit_position);

//        // Invert direction to that terrain appears to move with the mouse.
//        direction *= -1;

//        Vector3 position = camera_position + direction;

//        transform.position = position;
//    }
//}
