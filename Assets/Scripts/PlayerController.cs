using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    private PlayerModel Model = new PlayerModel(3, 5, 1);
    private PlayerView View = new PlayerView();

    private Rigidbody2D rb;
    private Vector2 movement;

    public int hp;
    
    private List<GameObject> bulletlist;

    // Start is called before the first frame update
    void Start()
    {
        hp = Model.Hp;
        bulletlist = ManagerPool.instance.bulletlist;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Model.Speed * Time.fixedDeltaTime);
    }


    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Shoot()
    {
        for (int i = 0; i < bulletlist.Count; i++)
        {
            if (!bulletlist[i].activeInHierarchy)
            {
                bulletlist[i].transform.position = firePoint.position;
                bulletlist[i].SetActive(true);
                break;
            }
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (hp > 0)
        {
            hp = hp - damage;
            View.SetHp(hp);
            Debug.Log(hp);
        }
        if (hp == 0)
        {
            GameManager.instance.GameOver();
        }

    }

    public void LoadData(Save.EnemySaveData save)
    {
        transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
    }

}
