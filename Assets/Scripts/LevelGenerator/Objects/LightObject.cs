using UnityEngine;

public class LightObject : ObstacleObject
{
    public Light lightScriptableObj;
    public CircleCollider2D lightCollider;

    public override void SetValues(MapTileObject newNestedTile)
    {
        obstacleSprite.sprite = lightScriptableObj.sprite;
        Vector3 currScale = transform.localScale;
        Vector3 newSize = new Vector3(currScale.x * lightScriptableObj.Radius, currScale.y * lightScriptableObj.Radius, 0);
        transform.localScale = newSize;
        nestedMapTile = newNestedTile;
        AdjustColliderDiameter();
    }    
    
    public void SetValues()
    {
        obstacleSprite.sprite = lightScriptableObj.sprite;
        Vector3 currScale = transform.localScale;
        Vector3 newSize = new Vector3(currScale.x * lightScriptableObj.Radius, currScale.y * lightScriptableObj.Radius, 0);
        transform.localScale = newSize;
        AdjustColliderDiameter();
    }

    private void AdjustColliderDiameter()
    {
        lightCollider.radius = lightScriptableObj.Radius;
    }
}
