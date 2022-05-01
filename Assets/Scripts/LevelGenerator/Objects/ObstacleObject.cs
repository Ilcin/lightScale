using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleObject : MonoBehaviour
{
    public MapTileObject nestedMapTile;
    public Vector2 position = new Vector2(0, 0);
    public SpriteRenderer obstacleSprite;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: implement obstacle trigger behaviour
        Debug.Log("Ouch! Collision!");
    }

    public abstract void SetValues(MapTileObject newNestedTile);

    public void PositionObstacle()
    {
        Vector2 newPos;
        float borderPadding = 1.5f; //to prevent obstacle hanging in border
        float newX = Random.Range(
            nestedMapTile.transform.position.x - nestedMapTile.offsetW/2 + borderPadding,
            nestedMapTile.transform.position.x + nestedMapTile.offsetW/2 - borderPadding);
        float newY = Random.Range(
            nestedMapTile.transform.position.y - nestedMapTile.offsetH / 2 + borderPadding,
            nestedMapTile.transform.position.y + nestedMapTile.offsetH / 2 - borderPadding);
        newPos = new Vector2(newX, newY);
        this.position = newPos;
        transform.position = new Vector3(newPos.x, newPos.y, 0);
    }
}
