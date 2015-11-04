using UnityEngine;
using System.Collections;
using System;

public class Shotgun : GunType
{
    Sprite shotgunSprite;
    ProjectileFactory projectileFactory;

    const float shotSpeed = 10.0f;

    public override float GetShotFrequency()
    {
        return 1.0f;
    }

    public override Sprite GetSprite()
    {
        return shotgunSprite;
    }

    public override void Initialize(GameObject parent)
    {
        shotgunSprite = Resources.Load<Sprite>(@"temp_shotgun");
        projectileFactory = Resolver.Instance.GetController<ProjectileFactory>();
    }

    public override void Shoot(Vector2 location, Vector2 direction)
    {
        GameObject newBulletCenter = projectileFactory.NewNormalProjectile();
        newBulletCenter.transform.position = location;
        newBulletCenter.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;

        GameObject newBulletLeft = projectileFactory.NewNormalProjectile();
        newBulletLeft.transform.position = location;
        newBulletLeft.GetComponent<Rigidbody2D>().velocity = Quaternion.AngleAxis(-45, Vector3.forward) * direction * shotSpeed;

        GameObject newBulletRight = projectileFactory.NewNormalProjectile();
        newBulletRight.transform.position = location;
        newBulletRight.GetComponent<Rigidbody2D>().velocity = Quaternion.AngleAxis(45, Vector3.forward) * direction * shotSpeed;
    }
}
