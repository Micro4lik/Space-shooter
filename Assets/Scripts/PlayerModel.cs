using UnityEngine.Events;

public class PlayerModel
{
    public int Hp = 3;
    public int MaxHp = 3;

    public float Speed = 5f;
    public int Damage = 1;

    public int winCondition = 10;

    public PlayerModel(int maxHp, float speed, int damage)
    {
        MaxHp = maxHp;
        Hp = MaxHp;
        Speed = speed;
        Damage = damage;
    }

}
