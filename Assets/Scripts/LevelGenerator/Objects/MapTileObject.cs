using System.Collections.Generic;
using UnityEngine;

public class MapTileObject : MonoBehaviour
{
    public SpriteRenderer borderSpriteRenderer;
    public MapTile mapTile;
    public float offsetW;
    public float offsetH;
    public int depth = 0;
    public Vector2 position = new Vector2(0, 0);

    public bool isBoundary = false;

    public Dictionary<string, Vector2> directionsDictionary;
    public Dictionary<string, MapTileObject> neighbourDictionary;

    public float neighbourProbability = 0.75f;

    public void Initialize()
    {
        SetOffset();
        SetNeighbours();
        SetDirection();
    }

    public bool HasDirAsNeighbour(Vector2 dir)
    {
        //check if a neighbour has already been initialized
        var key = TileUtility.MapDirectionToString(dir);
        return neighbourDictionary.ContainsKey(key);
    }    
   
    private void SetOffset()
    {
        offsetH = transform.localScale.y;
        offsetW = transform.localScale.x;
    }
    
    private void SetNeighbours()
    {
        neighbourDictionary = new Dictionary<string, MapTileObject>();
    }

    private void SetDirection()
    {
        directionsDictionary = new Dictionary<string, Vector2>()
        {
            {"U", Vector2.up},
            {"D", Vector2.down},
            {"L", Vector2.left},
            {"R", Vector2.right}
        };
    }
}
