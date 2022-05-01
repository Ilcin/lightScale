using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : ObstacleBehaviour<WallObject>
{
    void Start()
    {
        //skip start and Endtile
        MapTileObject tile = nestedTile.GetComponent<MapTileObject>();

        if (tile != null && Vector2.Distance(tile.position, Vector2.zero) > 0.5f && !tile.mapTile.isGoal)
        {
            GenerateObstacles();
        }
    }
}
