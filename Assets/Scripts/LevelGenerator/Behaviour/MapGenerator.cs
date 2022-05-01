using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject map;
    public MapTileObject startTile;
    public List<MapTileObject> tilesList;

    [Header("Private Variables")]
    [SerializeField]
    private int maxNumTiles = 20;
    [SerializeField]
    private int numTiles = 0;
    [SerializeField]
    private int minNumTiles = 30; 
    [SerializeField]
    private float innerTileProbability = 0.25f;

    public static event Action SpawnPlayerAtSpawnPosition;
    public static void CallSpawnPlayerAtSpawnPosition()
    {
        SpawnPlayerAtSpawnPosition?.Invoke();
    }

    private void Start()
    {
        //create Map 
        GenerateMap();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Generate New Map");
            CallSpawnPlayerAtSpawnPosition();
            GenerateMap();
        }
    }

    private void ClearMap()
    {
        Database.Instance.ResetTileProperties();

        foreach (MapTileObject tile in tilesList)
        {
            if (tile != startTile)
            {
                Destroy(tile.gameObject);
            }
        }
        tilesList.Clear();
    }

    private void GenerateMap()
    {

        ClearMap();

        numTiles = UnityEngine.Random.Range(minNumTiles, maxNumTiles);

        GenerateStartTile();

        CreateNeighboursForNewTiles();

        SetAllNeighbours();
        //Find all BoundaryTiles
        FindAndSetTiles();

        SetGoalTile();

        //DebugLogAllNeighbours();
    }

    private void SetGoalTile()
    {
        int goalTileIndex = UnityEngine.Random.Range(1, tilesList.Count - 1);
        tilesList[goalTileIndex].mapTile.isGoal = true;
        Debug.Log("GoalTile is:" + tilesList[goalTileIndex].position);
    }

    private void SetAllNeighbours()
    {
        foreach (var tile in tilesList)
        {
            foreach (KeyValuePair<string, Vector2> direction in tile.directionsDictionary)
            {
                Vector2 newPos = tile.position + direction.Value;
                if (!TileIsFree(newPos) && !tile.neighbourDictionary.ContainsKey(direction.Key))
                {
                    tile.neighbourDictionary.Add(direction.Key, tilesList.Find(x => x.position == newPos));
                }
            }
        }
    }
    private void FindAndSetTiles()
    {
        foreach(var tile in tilesList)
        {
            if(tile.neighbourDictionary.Count == 4)
            {
                //this is an inner tile
                tile.mapTile = GetInnerTileRandom();
                if (TileUtility.ProbabilityCheck(innerTileProbability))
                {
                    tile.borderSpriteRenderer.sprite = tile.mapTile.background;
                }
                Debug.Log("Tile " + tile.position + " is an inner tile");
            }
            else //this is a border tile
            {
                tile.isBoundary = true;
                //Set boundary values depending on where a free tile is. 
                //depending on boundary assign a MapTile
                //Set MapTiles
                SetMapTile(tile);
                Debug.Log("Tile " + tile.position + " is a border tile");
            }
        }

        
    }

    private void SetMapTile(MapTileObject tile)
    {

        string tileId = "";
        foreach (KeyValuePair<string, Vector2> direction in tile.directionsDictionary)
        {
            if(TileIsFree(tile.position + direction.Value))
            {
                //If given dir is free -> this direction is a border
                if(tileId.Length == 0)
                {
                    tileId += direction.Key;
                }
                else
                {
                    tileId += "-" + direction.Key;
                }
            }
        }
        tile.mapTile = GetBorderTileByID(tileId);
        tile.borderSpriteRenderer.sprite = tile.mapTile.background;
    }

    private void LogAllNeighbours()
    {
        if (numTiles <= 0)
        {
            foreach (var tile in tilesList)
            {
                foreach (KeyValuePair<string, Vector2> dir in tile.directionsDictionary)
                {
                    if (tile.HasDirAsNeighbour(dir.Value))
                    {
                        Debug.Log(tile + " has a neighbour in direction: " + dir.Value + "/" + dir.Key +
                        "\n the neighbour is: " + tile.neighbourDictionary[TileUtility.MapDirectionToString(dir.Value)]);
                    }
                }
            }
        }
    }

    private void GenerateStartTile()
    {
        startTile.Initialize();
        startTile.mapTile = GetBorderTileByID("M-01");
        startTile.position = new Vector2(0, 0);
        startTile.mapTile.isStart = true;
        startTile.Initialize();
        numTiles--;
        tilesList.Add(startTile);
    }

    private void CreateNeighboursForNewTiles()
    {
        int endOfCurrentTileList = tilesList.Count;
        for (int i = 0; i < endOfCurrentTileList; i++)
        {
            var tile = tilesList[i];
            CreateNeighbour(tile);
        }

        //If there are still tiles to create
        if (numTiles > 0)
        {
            CreateNeighboursForNewTiles();
        }
    }

    private void CreateNeighbour(MapTileObject tile)
    {
        foreach (KeyValuePair<string, Vector2> direction in tile.directionsDictionary)
        {
            bool canCreateNeighbour =
                !tile.HasDirAsNeighbour(direction.Value) &&
                TileUtility.ProbabilityCheck(tile.neighbourProbability) &&
                numTiles > 0 &&
                TileIsFree(tile.position + direction.Value);

            if (canCreateNeighbour)
            {
                MapTileObject newTile = CreateNewTile(direction.Value, tile);
                tilesList.Add(newTile);
            }
        }
    }

    private bool TileIsFree(Vector2 newCoord)
    {
        return !tilesList.Any(x => x.position == newCoord);
    }


    private MapTileObject CreateNewTile(Vector2 direction, MapTileObject prevTile)
    {
        GameObject newTile = Instantiate(tilePrefab);
        newTile.transform.parent = map.transform;
        MapTileObject newMaptTileObject = newTile.GetComponent<MapTileObject>();

        newMaptTileObject.Initialize();
        newMaptTileObject.position = prevTile.position + direction;
        newMaptTileObject.name = newMaptTileObject.position.ToString();

        PositionTileInScene(newMaptTileObject);

        newMaptTileObject.depth = prevTile.depth + 1;
        newMaptTileObject.neighbourProbability = Mathf.Abs
            (
                prevTile.neighbourProbability - UnityEngine.Random.Range(0.05f, Mathf.Abs((float)prevTile.neighbourProbability - 0.1f))
            );

        //TODO:
        //Add MapTile scriptableObj Data according to boundaries

        numTiles--;
        return newMaptTileObject;
    }


    private void PositionTileInScene(MapTileObject currentTile)
    {
        currentTile.transform.position = new Vector3
        (
            currentTile.position.x * currentTile.offsetW,
            currentTile.position.y * currentTile.offsetH,
            0
        );
    }



    private MapTile GetBorderTileByID(string ID)
    {
        return Database.GetBorderMapTileByID(ID);
    }

    private MapTile GetInnerTileRandom()
    {
        return Database.GetRandomInnerTile(); ;
    }

}
