using UnityEngine;
using System.Collections;
using System;

public class Rifle : GunType
{
    Sprite rifleSprite;
    ProjectileFactory projectileFactory;

    const float shotSpeed = 10.0f;

    public override void Initialize(GameObject parent)
    {
        rifleSprite = Resources.Load<Sprite>(@"temp_rifle");
        projectileFactory = Resolver.Instance.GetController<ProjectileFactory>();
    }

    public override void Shoot(Vector2 location, Vector2 direction)
    {
        GameObject newBullet = projectileFactory.NewNormalProjectile();
        newBullet.transform.position = location;
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
    }

    public override float GetShotFrequency()
    {
        return 0.25f;
    }

    public override Sprite GetSprite()
    {
        return rifleSprite;
    }
}
