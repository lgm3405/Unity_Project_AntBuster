using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChickenMove : MonoBehaviour
{
    private GameObject eggReturn;
    private ChickenSpawn chickenSpawn;
    private Rigidbody ChickenRigidbody = default;
    private Transform targetEgg = default;
    private Transform targetReturn = default;
    private int antMoveType = default;
    private int randomX = default;
    private int randomZ = default;
    private float time = default;
    private float moveTime = default;

    public static int hp = default;
    public static int level = default;
    public bool getEgg = false;
    public GameObject chickenEgg = default;

    private void Awake()
    {
        ChickenRigidbody = GetComponent<Rigidbody>();
        targetEgg = FindObjectOfType<Destination>().transform;
        targetReturn = FindObjectOfType<ChickenSpawn>().transform;
        chickenSpawn = GameObject.Find("StartTunnul").GetComponent<ChickenSpawn>();
        eggReturn = GameObject.Find("Destination");

        antMoveType = 0;
        randomX = 0;
        randomZ = 0;
        time = 0;
        moveTime = 0.5f;
        hp = 0;
        level = 0;
    }

    void Start()
    {
        hp = GameManager.instance.level * 15;
        level = GameManager.instance.level;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= moveTime)
        {
            if (GameManager.instance.isGameOver == true) { return; }

            antMoveType = Random.Range(0, 100);
            if (antMoveType < 40)
            {
                randomX = Random.Range(-5, 5);
                randomZ = Random.Range(-5, 5);
                float xSpeed = randomX * 2f;
                float zSpeed = randomZ * 2f;

                Vector3 targetPos = this.transform.position + new Vector3(xSpeed, 0f, zSpeed);
                Vector3 dir = targetPos - this.transform.position;
                dir.Normalize();
                this.transform.forward = dir;

                Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
                ChickenRigidbody.velocity = newVelocity;
            }
            else
            {
                if (getEgg == false)
                {
                    this.transform.LookAt(targetEgg);
                    ChickenRigidbody.velocity = transform.forward * 10;
                }
                else
                {
                    this.transform.LookAt(targetReturn);
                    ChickenRigidbody.velocity = transform.forward * 10;
                }
                
            }

            time = 0;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bullet")
        {
            collider.gameObject.SetActive(false);
            Destroy(collider.gameObject, 1f);
        }
    }

    public void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            GameManager.instance.money += GameManager.instance.level + 1;
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 1f);
            chickenSpawn.ants -= 1;

            if (getEgg == true)
            {
                eggReturn.GetComponent<Destination>().EggReturn();
            }
        }
    }

    public void EggOn()
    {
        chickenEgg.gameObject.SetActive(true);
    }

    public void EggOff()
    {
        chickenEgg.gameObject.SetActive(false);
    }
}
