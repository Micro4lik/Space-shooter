using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public LevelController levelController;
    public PlayerController playerController;
    public EnemyController enemyController;
    public ManagerPool managerPool;

    public GameObject GameOverPopup;

    public int KilledEnemies;

    public float spawnRate = 0.5f;
    
    private List<GameObject> enemylist;

    public bool isPause;
    

    void Start()
    {
        levelController = LevelController.instance;
        playerController = PlayerController.instance;
        enemyController = EnemyController.instance;
        managerPool = ManagerPool.instance;

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

    public void PauseGame()
    {
        isPause = true;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        isPause = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPopup.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeLevel(int level)
    {
        switch (level)
            {
                case 1:
                    levelController.Level = 1;
                    break;
                case 2:
                    levelController.Level = 2;
                break;
                case 3:
                    levelController.Level = 3;
                break;
                default:
                    Debug.Log("default");
                    break;
            }
    }

    public void InitializeNewLevel()
    {
        Time.timeScale = 1;

        levelController.ChangeLevel();

        playerController.gameObject.transform.position = playerController.PlayerPosition;
        for (int i = 0; i < enemylist.Count; i++)
        {
                enemylist[i].SetActive(false);
                enemylist[i].GetComponent<EnemyView>().SetRandomPosition();
        }
        for (int i = 0; i < managerPool.bulletlist.Count; i++)
        {
            managerPool.bulletlist[i].SetActive(false);
        }
        levelController.View.SetKilledEnemies(LevelController.instance.eToWin);
        playerController.View.SetHp(3);

        playerController.hp = 3;
        levelController.kEnemiew = 0;
        
        levelController.View.ChangeLevelStateButtons();
    }
    
}
