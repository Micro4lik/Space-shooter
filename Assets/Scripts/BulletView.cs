using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private float lifeTime = 2f;
    
    void OnEnable()
    {
        Invoke("hideBullet", lifeTime);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "enemy")
        {
            coll.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            //gameObject.SetActive(false);
        }
    }
}
