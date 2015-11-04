using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Gun : MonoBehaviour
{
    GunType gunType;
    Player player;
    SpriteRenderer mySpriteRenderer;

    float shotFrequency;
    float shotTimer;

    enum GunTypeEnum
    {
        Rifle,
        Shotgun
    };

    GunTypeEnum currentGunType;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        player = Resolver.Instance.GetController<Player>();

        SwitchGuns(GunTypeEnum.Rifle);
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if (Resolver.Instance.GetController<InputController>().GetChangeGuns())
        {
            if (currentGunType == GunTypeEnum.Rifle)
            {
                SwitchGuns(GunTypeEnum.Shotgun);
            }
            else
            {
                SwitchGuns(GunTypeEnum.Rifle);
            }
        }
        else if (shotTimer <= 0.0f && Resolver.Instance.GetController<InputController>().GetShootPressed())
        {
            gunType.Shoot(player.GunLocation, player.ProjectileVector);

            shotTimer = shotFrequency;
        }
    }

    void SwitchGuns(GunTypeEnum gunTypeEnum)
    {
        currentGunType = gunTypeEnum;

        if (gunTypeEnum == GunTypeEnum.Rifle)
        {
            gunType = new Rifle();
        }
        else
        {
            gunType = new Shotgun();
        }
        gunType.Initialize(gameObject);
        mySpriteRenderer.sprite = gunType.GetSprite();

        shotFrequency = gunType.GetShotFrequency();
        shotTimer = 0.0f;
    }

}
