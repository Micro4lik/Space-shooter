using UnityEngine.Events;

public class PlayerModel
{
    public int NormalizedHp
    {
        get { return Hp / MaxHp; }
    }

    //public bool IsHpChanged { get; private set; }

    public int Hp = 3; //{ get; set; }
    public int MaxHp = 3; //{ get; set; }

    public float Speed = 5f; //{ get; set; }
    public int Damage = 1; //{ get; set; }

    public int winCondition = 10;

    public PlayerModel(int maxHp, float speed, int damage)
    {
        MaxHp = maxHp;
        Hp = MaxHp;
        Speed = speed;
        Damage = damage;
    }

    public float GetSpeed()
    {
        return Speed;
    }

    //действует в начале каждого кадра, в конце каждого кадра затирается
    //public void LateUpdate()
    //{
    //    IsHpChanged = false;
    //}

    //public UnityAction<int> OnHealthChanged;

    /*public void ReceiveDamage(int damage)
    {
        Hp = Hp - damage;
        //IsHpChanged = true;
        if (OnHealthChanged != null)
        {
            OnHealthChanged(NormalizedHp);
        }
    }*/
}
