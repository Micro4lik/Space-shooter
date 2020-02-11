using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Singleton<EnemyController>
{
    private Transform Player;
    private Vector3 normalizeDirection;
    private float speed = 10f;
    
    void Start()
    {
        Player = PlayerController.instance.transform;
    }
    
    void Update()
    {
        normalizeDirection = (Player.position - transform.position).normalized;
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }

    public void LoadData(Save.EnemySaveData save)
    {
        GetComponent<EnemyView>().OnDisable();
        transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
    }
}
