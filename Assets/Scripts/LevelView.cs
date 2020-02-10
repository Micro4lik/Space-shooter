using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    //private LevelModel Model;

    void Start()
    {
        
    }

    public void SetKilledEnemies(int enemies)
    {
        LevelController.instance.enemies.text = "Enemies: " + enemies.ToString();
    }

}
