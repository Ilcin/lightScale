using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Walls Database", menuName = "Assets/Databases/WallsDatabase")]
public class WallDatabase : ScriptableObject
{
    public List<Wall> wallList;
}
