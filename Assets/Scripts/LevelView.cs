using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    public void SetKilledEnemies(int enemies)
    {
        LevelController.instance.enemies.text = "Enemies: " + enemies.ToString();
    }

    public void ChangeGameOverText(string text)
    {
        LevelController.instance.gameOverText.text = text;
    }

    public void ChangeButtonText(string text)
    {
        LevelController.instance.buttonNextLevel.text = text;
    }

    public void ChangeLevelStateButtons()
    {
        if (LevelController.instance.unlockedLevels > 1)
        {
            LevelController.instance.LevelButtons[1].interactable = true;
        }
        if (LevelController.instance.unlockedLevels > 2)
        {
            LevelController.instance.LevelButtons[2].interactable = true;
        }
    }

}
