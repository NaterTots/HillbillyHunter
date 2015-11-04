using UnityEngine;
using System.Collections;

public abstract class GunType
{
    /// <summary>
    /// Initialize the display of the gun.
    /// </summary>
    /// <param name="parent"></param>
    public abstract void Initialize(GameObject parent);

    /// <summary>
    /// Shoot the gun at a given location in the given direction.
    /// </summary>
    /// <param name="location"></param>
    /// <param name="direction"></param>
    public abstract void Shoot(Vector2 location, Vector2 direction);

    /// <summary>
    /// This is the minimum time (in seconds) allowed between shots
    /// </summary>
    /// <returns></returns>
    public abstract float GetShotFrequency();

    /// <summary>
    /// The display sprite of the gun.
    /// </summary>
    /// <returns></returns>
    public abstract Sprite GetSprite();
}
