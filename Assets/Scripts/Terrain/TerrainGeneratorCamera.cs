using UnityEngine;
using System.Collections;

public class TerrainGeneratorCamera : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
        TerrainConfiguration terrain = Resolver.Instance.GetController<GlobalSettings>().terrainConfiguration;
        GetComponent<Camera>().orthographicSize = Mathf.Max(terrain.World.height, terrain.World.width) / 2 + 5; //the 5 is arbitrary, just to give a slight border to the terrain
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
