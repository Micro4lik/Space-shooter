using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletModel Model = new BulletModel(2f, 20f);

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Model.BulletForce * Time.deltaTime;
    }
}
