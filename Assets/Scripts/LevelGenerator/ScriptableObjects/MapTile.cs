using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Maptile", menuName = "Maptile")]
public class MapTile : ScriptableObject
{
    #region bounds
    public bool boundsUp = false;
    public bool boundsDown = false;
    public bool boundsLeft = false;
    public bool boundsRight = false;
    #endregion

    public string tileID;
    public bool isStart;
    public bool isGoal;
    public bool isFound;


    public Sprite background;
    public List<Wall>wallList;
    public List<Light>lightList;

}
