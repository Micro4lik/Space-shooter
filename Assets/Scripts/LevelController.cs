using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class LevelController : Singleton<LevelController>
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI enemies;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI buttonNextLevel;

    public Button[] LevelButtons;

    public LevelModel Model = new LevelModel(1, 10);
    public LevelView View;

    public int kEnemiew;
    public int currentEnemies;
    public int eToWin;

    public int Level;

    public int unlockedLevels;

    public void ChangeEnemyDestoyed()
    {
        kEnemiew += 1;
        currentEnemies = eToWin - kEnemiew;
        View.SetKilledEnemies(currentEnemies);

        if (kEnemiew == eToWin)
        {
            Level += 1;
            ChangeLevel();
            //PlayerPrefs.SetInt("IsFirstRun", 0);
            View.ChangeGameOverText("Victory!");
            if (Level == 3)
            {
                View.ChangeButtonText("Retry");
            }
            else
            {
                View.ChangeButtonText("Next level");
            }

            
            if (Level == 2 && unlockedLevels < 2)
            {
                unlockedLevels = 2;
            }
            else if (Level == 3 && unlockedLevels < 3)
            {
                unlockedLevels = 3;
            }

            GameManager.instance.GameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = Model.Level;
        kEnemiew = Model.KilledEnemies;
        eToWin = Model.EnemiesToWin;

        unlockedLevels = 1;
    }
    
    public void ChangeLevel()
    {
        switch (Level)
        {
            case 1:
                Debug.Log("Load level 1");
                eToWin = 10;
                break;
            case 2:
                Debug.Log("Load level 2");
                eToWin = 20;
                break;
            case 3:
                Debug.Log("Load level 3");
                eToWin = 30;
                break;
            default:
                Debug.Log("default");
                break;
        }
        
    }

}
