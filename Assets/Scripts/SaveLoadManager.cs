using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;

    private List<GameObject> EnemySaves = new List<GameObject>();
    private List<GameObject> BulletsSaves = new List<GameObject>();

    public PlayerView pView;
    public LevelView lView;
    public EnemyView eView;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        EnemySaves = ManagerPool.instance.enemylist;
        BulletsSaves = ManagerPool.instance.bulletlist;
        filePath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        save.SaveEnemies(EnemySaves);
        save.SaveBullets(BulletsSaves);
        save.Health = PlayerController.instance.hp;
        save.Score = LevelController.instance.kEnemiew;
        save.SavePlayer(Player);

        bf.Serialize(fs, save);

        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        int i = 0;
        foreach (var enemy in save.EnemiesData)
        {
            EnemySaves[i].GetComponent<EnemyController>().LoadData(enemy);
            i++;
        }

        i = 0;
        foreach (var bullet in save.BulletsData)
        {
            BulletsSaves[i].GetComponent<BulletController>().LoadData(bullet);
            i++;
        }

        PlayerController.instance.hp = save.Health;
        pView.SetHp(save.Health);
        LevelController.instance.kEnemiew = save.Score;
        lView.SetKilledEnemies(LevelController.instance.eToWin - save.Score);

        Player.GetComponent<PlayerController>().LoadData(save.player);
        


    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct EnemySaveData
    {
        public Vec3 Position;

        public EnemySaveData(Vec3 pos)
        {
            Position = pos;
        }
    }

    public List<EnemySaveData> EnemiesData = new List<EnemySaveData>();

    public EnemySaveData player;

    public List<EnemySaveData> BulletsData = new List<EnemySaveData>();

    public int Score;
    public int Health;

    public void SaveEnemies(List<GameObject> enemies)
    {
        foreach (var go in enemies)
        {
            var em = go.GetComponent<EnemyController>();

            Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);

            EnemiesData.Add(new EnemySaveData(pos));

        }
    }

    public void SaveBullets(List<GameObject> bullets)
    {
        foreach (var go in bullets)
        {
            var em = go.GetComponent<BulletController>();

            Vec3 pos = new Vec3(go.transform.position.x, go.transform.position.y, go.transform.position.z);

            BulletsData.Add(new EnemySaveData(pos));

        }
    }

    public void SavePlayer(GameObject pl)
    {

        var pm = pl.GetComponent<PlayerController>();

        Vec3 pos = new Vec3(pl.transform.position.x, pl.transform.position.y, pl.transform.position.z);

        player.Position = pos;
        
    }
    
}
