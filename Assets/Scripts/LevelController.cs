using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : Singleton<LevelController>
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI enemies;

    private LevelModel Model = new LevelModel(1, 10);
    private LevelView View = new LevelView();

    public int kEnemiew;
    public int currentEnemies;
    public int eToWin;

    public void ChangeEnemyDestoyed()
    {
        kEnemiew += 1;
        currentEnemies = eToWin - kEnemiew;
        View.SetKilledEnemies(currentEnemies);

        if (kEnemiew == eToWin)
        {
            Model.Level += 1;
            NextLevel();
            GameManager.instance.GameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        kEnemiew = Model.KilledEnemies;
        eToWin = Model.EnemiesToWin;
    }

    void NextLevel()
    {
        switch (Model.Level)
        {
            case 1:
                Debug.Log("Load level 1");
                Model.EnemiesToWin = 10;
                break;
            case 2:
                Debug.Log("Load level 2");
                Model.EnemiesToWin = 20;
                break;
            case 3:
                Debug.Log("Load level 3");
                Model.EnemiesToWin = 30;
                break;
            default:
                Debug.Log("default");
                break;
        }

        View.SetKilledEnemies(Model.EnemiesToWin);

    }

}
