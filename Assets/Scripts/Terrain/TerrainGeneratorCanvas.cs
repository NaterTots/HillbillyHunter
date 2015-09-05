using UnityEngine;
using System.Collections;

public class TerrainGeneratorCanvas : MonoBehaviour 
{
    public void OnRedrawTerrain()
    {
        Terrain terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        terrain.ResetTerrain();
        terrain.GenerateTerrain();
    }
}
