using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light Database", menuName = "Assets/Databases/LightsDatabase")]
public class LightsDatabase : ScriptableObject
{
    public List<Light> lightsList;
}