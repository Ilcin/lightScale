using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public static Database Instance;
    public  TilesDatabase borderTiles;
    public  TilesDatabase innerTiles;
    public WallDatabase obstacles;
    public LightsDatabase lights;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetTileProperties()
    {
        foreach (MapTile borderTile in borderTiles.mapTileList)
        {
            borderTile.isFound = false;
            borderTile.isGoal = false;
            borderTile.isStart = false;
        }
        foreach (MapTile innerTile in innerTiles.mapTileList)
        {
            innerTile.isFound = false;
            innerTile.isGoal = false;
            innerTile.isStart = false;
        }
    }
      
    public static MapTile GetBorderMapTileByID(string ID)
    {
        return Instance.borderTiles.mapTileList.FirstOrDefault(i => i.tileID == ID);
    }  
    
    public static MapTile GetRandomInnerTile()
    {
        return Instance.innerTiles.mapTileList[Random.Range(0, Instance.innerTiles.mapTileList.Count())];
    }

    public static Wall GetRandomWall()
    {
        return Instance.obstacles.wallList[Random.Range(0, Instance.obstacles.wallList.Count())];
    }

    public static Light GetRandomLight()
    {
        return Instance.lights.lightsList[Random.Range(0, Instance.lights.lightsList.Count())];
    }
}
