using UnityEngine;
using System.Collections;
using System;

public class ProjectileFactory : MonoBehaviour, IController
{
    ObjectPool normalProjectilePool = new ObjectPool();

    public GameObject normalProjectilePrefab;

	// Use this for initialization
	void Start ()
    {
        normalProjectilePool.objectPrefab = normalProjectilePrefab;
        normalProjectilePool.parentContainer = this.gameObject;
        normalProjectilePool.Initialize(30);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public GameObject NewNormalProjectile()
    {
        return normalProjectilePool.InitNewObject();
    }

    public void Cleanup()
    {
        
    }
}
