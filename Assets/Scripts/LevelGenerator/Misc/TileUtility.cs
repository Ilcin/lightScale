using UnityEngine;

public static class TileUtility
{
    public static string MapDirectionToString(Vector2 direction)
    {
        return direction switch
        {
            Vector2 v when v.Equals(Vector2.up) => "U",
            Vector2 v when v.Equals(Vector2.down) => "D",
            Vector2 v when v.Equals(Vector2.left) => "L",
            Vector2 v when v.Equals(Vector2.right) => "R",
            _ => throw new System.Exception("No Direction to map!"),
        };
    }

    public static string InverseDirection(string dir)
    {
        return dir switch
        {
            "U" => "D",
            "D" => "U",
            "L" => "R",
            "R" => "L",
            _ => throw new System.Exception("Something went terribly wrong."),
        };
    }

    public static  bool ProbabilityCheck(float val)
    {
        return Random.value < val;
    }
}
