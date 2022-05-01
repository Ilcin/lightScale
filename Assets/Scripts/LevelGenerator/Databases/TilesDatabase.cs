using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tiles Database", menuName = "Assets/Databases/TilesDatabase")]
public class TilesDatabase : ScriptableObject
{
    public List<MapTile> mapTileList;
}
