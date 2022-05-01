using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour<T>: MonoBehaviour where T : ObstacleObject
{
    public GameObject nestedTile;
    public GameObject obstaclePrefab;
    public List<T> obstaclesList;
    public float spawnProbabilityObstacle;

    [Header("Privates")]
    [SerializeField]
    private int maxNumObstacles = 2;  

    public void GenerateObstacles()
    {
        for(int i = 0; i < maxNumObstacles; i++)
        {
            if (TileUtility.ProbabilityCheck(spawnProbabilityObstacle))
            {
                GameObject obstacle = Instantiate(obstaclePrefab);
                obstacle.transform.parent = nestedTile.transform;
                T obstacleObject = obstacle.GetComponent<T>();
                obstaclesList.Add(obstacleObject);
                
                switch (typeof(T))
                {
                    case Type lightType when lightType == typeof(LightObject):
                        var test = obstacleObject as LightObject;
                        test.lightScriptableObj = Database.GetRandomLight();
                        break;
                    case Type wallType when wallType == typeof(WallObject):
                        var testwall = obstacleObject as WallObject;
                        testwall.wall = Database.GetRandomWall();
                        break;
                }

                //obstacleObject.obstacle = typeof(T) switch
                //{
                //    Type lightType when lightType == typeof(LightObject) => Database.GetRandomLight(),
                //    Type wallType when wallType == typeof(WallObject) => Database.GetRandomWall(),
                //    _ => throw new Exception("Databases! Errer"),
                //};

                //Set Obstacle Values
                obstacleObject.SetValues(nestedTile.GetComponent<MapTileObject>());
                //Assign position within Tile
                obstacleObject.PositionObstacle();
            }
        }

    
       
    }
}
