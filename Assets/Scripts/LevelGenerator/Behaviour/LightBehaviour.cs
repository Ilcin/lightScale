using UnityEngine;

public class LightBehaviour : ObstacleBehaviour<LightObject>
{
    void Start()
    {
        //skip start and Endtile
        MapTileObject tile = nestedTile.GetComponent<MapTileObject>();

        if (tile != null && Vector2.Distance(tile.position, Vector2.zero) > 1 && !tile.mapTile.isGoal)
        {
            GenerateObstacles();
        }
    }
}
