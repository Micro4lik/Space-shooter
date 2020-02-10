using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public PlayerModel Model;

    public LevelController levelController;

    public GameObject GameOverPopup;

    public int KilledEnemies;

    public float spawnRate = 0.5f;
    
    private List<GameObject> enemylist;
    
    void Start()
    {
        levelController = new LevelController();

        KilledEnemies = 0;

        enemylist = ManagerPool.instance.enemylist;

        StartCoroutine(EnemySpawner(spawnRate));
    }

    IEnumerator EnemySpawner(float time)
    {
        while (true)
        {
            for (int i = 0; i < enemylist.Count; i++)
            {
                if (!enemylist[i].activeInHierarchy)
                {
                    enemylist[i].SetActive(true);
                    break;
                }
            }
            yield return new WaitForSeconds(time);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPopup.SetActive(true);
    }

    void NextLevel()
    {
        Retry();
    }

}
