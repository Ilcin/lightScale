using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : ObstacleObject
{
    public Wall wall;
    public Collider2D obstacleCollider;


    public override void SetValues(MapTileObject newNestedTile)
    {
        obstacleSprite.sprite = wall.sprite;
        Vector3 currScale = transform.localScale;
        Vector3 newSize = new Vector3(currScale.x * wall.width, currScale.y * wall.height, 0);
        transform.localScale = newSize;
        nestedMapTile = newNestedTile;
    }
}
