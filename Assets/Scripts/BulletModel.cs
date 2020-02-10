using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{

    public float LifeTime = 2f;

    public float BulletForce = 20f;

    public BulletModel(float lifeTime, float bulletForce)
    {
        LifeTime = lifeTime;
        BulletForce = bulletForce;
    }

}
