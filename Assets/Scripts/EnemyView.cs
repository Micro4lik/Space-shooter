using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyModel Model;
    private LevelController levelController;

    private float randY;

    void OnEnable()
    {
        Invoke("hideEnemy", Model.LifeTime);
    }

    void hideEnemy()
    {
        gameObject.SetActive(false);
        SetRandomPosition();
    }

    public void OnDisable()
    {
        CancelInvoke();
    }

    void Awake()
    {
        levelController = LevelController.instance;
        Model = new EnemyModel(3, 2.5f, 1, 5f);
        Model.PositionX = 10f;
        SetRandomPosition();
    }

    public void SetRandomPosition()
    {
        randY = Random.Range(-6.5f, 6.5f);
        Model.PositionY = randY;
        transform.position = new Vector3(Model.PositionX, Model.PositionY);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "bullet")
        {
            SetRandomPosition();
            LevelController.instance.ChangeEnemyDestoyed();
        }
        else if (coll.transform.tag == "Player")
        {
            SetRandomPosition();
        }

    }

}
