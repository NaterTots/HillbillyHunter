using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// TODO: Refactor VoidSpace and Biome to reduce redundant code.
/// </summary>
[System.Serializable]
public class VoidSpace
{
    private struct FloodFillMapPoint
    {
        internal TerrainMapPoint mapPoint;
        internal bool floodFilled;
        internal float distanceToCenter;
    }

    private List<FloodFillMapPoint> mapPoints = new List<FloodFillMapPoint>();

    private Terrain terrain;
    private TerrainMapPoint centerPoint;

    /// <summary>
    /// Denotes when the VoidSpace can no longer Flood Fill
    /// </summary>
    public bool FloodComplete = false;

    public void Initialize(TerrainMapPoint initPoint, Terrain t)
    {
        terrain = t;
        centerPoint = terrain.GetCenterPoint();

        terrain.SetPoint(initPoint, TerrainType.Empty);

        mapPoints.Add(new FloodFillMapPoint()
        {
             mapPoint = initPoint,
             floodFilled = false
        });
    }

    public void FloodFill(int points)
    {
        for (int i = 0; i < points && !FloodComplete; i++)
        {
            FloodFill();
        }
    }

    public void FloodFill()
    {
        //give priority to points that are closer to center
        

        //give priority towards directions that point towards the center
    }
}
