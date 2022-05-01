using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("This is the speed of the player.")]
    [SerializeField]
    [Range(1f, 10)]
    private float speed;

    private List<LightObject> lightsInRangeList;

    private void OnEnable()
    {
        MapGenerator.SpawnPlayerAtSpawnPosition += SpawnAtSpawnPositionOfMap;
    }

    private void OnDisable()
    {
        MapGenerator.SpawnPlayerAtSpawnPosition -= SpawnAtSpawnPositionOfMap;
    }

    private void Start()
    {
        lightsInRangeList = new List<LightObject>();
        SpawnAtSpawnPositionOfMap();
    }

    private void FixedUpdate()
    {
        AttractedByStrongestLight();
    }

    private void OnTriggerEnter2D(Collider2D lightCollider)
    {
        var light = lightCollider.GetComponentInParent<LightObject>();
        if (!lightsInRangeList.Contains(light))
        {
            lightsInRangeList.Add(light);
        }
    }

    private void OnTriggerExit2D(Collider2D lightCollider)
    {
        var light = lightCollider.GetComponentInParent<LightObject>();
        if (lightsInRangeList.Contains(light))
        {
            lightsInRangeList.Remove(light);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            SpawnAtSpawnPositionOfMap();
        }
    }

    private void AttractedByStrongestLight()
    {
        if (lightsInRangeList.Count == 0)
        {
            return;
        }

        var pos = transform.position;
        var acceleration = Vector3.zero;
        foreach (var light in lightsInRangeList)
        {
            if (light == null)
            {
                continue;
            }
            var direction = (light.gameObject.transform.position - pos);
            acceleration += (direction.normalized * light.lightScriptableObj.Intensity) / direction.sqrMagnitude;
        }
        transform.position += acceleration * speed * Time.fixedDeltaTime;
    }

    private void SpawnAtSpawnPositionOfMap()
    {
        // ToDo: Get the Map SpawnPosition
        transform.position = new Vector3(0, 0, 0);
    }
}
