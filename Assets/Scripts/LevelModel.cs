public class LevelModel
{
    public int Level = 1;
    public int EnemiesToWin;
    public int KilledEnemies = 0;

    public LevelModel(int level, int enemiesToWin)
    {
        Level = level;
        EnemiesToWin = enemiesToWin;
    }
}
