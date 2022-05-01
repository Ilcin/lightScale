using UnityEngine;

[CreateAssetMenu(fileName = "New Light", menuName = "Light")]
public class Light : ScriptableObject
{
    [Tooltip("The higher the range of the light the bigger is the impact of the light.")]
    [SerializeField]
    [Range(0.5f, 10)]
    private float radius;

    [Tooltip("The higher the intensity of the light the stronger the light becomes.")]
    [SerializeField]
    [Range(0.5f, 30)]
    private float intensity;

    public float Radius { get { return radius; } set { radius = value; } }

    public float Intensity { get { return intensity; } set { intensity = value; } }

    public Sprite sprite;
}