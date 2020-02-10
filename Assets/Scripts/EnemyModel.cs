public class EnemyModel
{
    public int Hp = 3;
    public int MaxHp = 3;

    public float Speed = 2.5f;
    public int Damage = 1;

    public float LifeTime = 5f;

    public float PositionX;
    public float PositionY;
    
    public EnemyModel(int maxHp, float speed, int damage, float lifeTime)
    {
        MaxHp = maxHp;
        Hp = MaxHp;
        Speed = speed;
        Damage = damage;
        LifeTime = lifeTime;
    }

}
