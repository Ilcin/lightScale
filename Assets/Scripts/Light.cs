//using System;
//using UnityEngine;

//public class Light : MonoBehaviour
//{
//    public float Range { get { return range; } set { range = value; } }

//    public float Intensity { get { return intensity; } set { intensity = value; } }

//    [Tooltip("The higher the range of the light the bigger is the impact of the light.")]
//    [SerializeField]
//    [Range(0.5f, 10)]
//    private float range;

//    [Tooltip("The higher the intensity of the light the stronger the light becomes.")]
//    [SerializeField]
//    [Range(0.5f, 30)]
//    private float intensity;

//    private CircleCollider2D circleCollider;

//    private void Start()
//    {
//        circleCollider = GetComponent<CircleCollider2D>();
//        AdjustColliderDiameter();
//    }

//    private void AdjustColliderDiameter()
//    {
//        circleCollider.radius = range;
//    }
//}
