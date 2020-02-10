using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerModel Model;

    public Rigidbody2D rb;
    private Vector2 movement;

    public void SetHp(int hp)
    {
        LevelController.instance.health.text = "Health: " + hp.ToString();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "enemy")
        {
            PlayerController.instance.ReceiveDamage(1);
        }
    }

}
