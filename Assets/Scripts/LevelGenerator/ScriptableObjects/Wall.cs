using UnityEngine;

[CreateAssetMenu(fileName = "New Wall", menuName = "Wall")]
public class Wall : ScriptableObject
{
    public Sprite sprite;
    public float height;
    public float width;
}
