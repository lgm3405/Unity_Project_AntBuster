using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChickenMove : MonoBehaviour
{
    private ChickenSpawn chickenSpawn;
    private Rigidbody ChickenRigidbody = default;
    private Transform target = default;
    private int antMoveType = default;
    private int randomX = default;
    private int randomZ = default;
    private float time = default;
    private float moveTime = default;

    public static int hp = default;
    public static int level = default;

    private void Awake()
    {
        ChickenRigidbody = GetComponent<Rigidbody>();
        target = FindObjectOfType<Destination>().transform;
        chickenSpawn = GameObject.Find("StartTunnul").GetComponent<ChickenSpawn>();
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
        hp = GameManager.instance.level * 10;
        level = GameManager.instance.level;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= moveTime)
        {
            antMoveType = Random.Range(0, 100);
            if (antMoveType < 40)
            {
                randomX = Random.Range(-5, 5);
                randomZ = Random.Range(-5, 5);
                float xSpeed = randomX * 1.5f;
                float zSpeed = randomZ * 1.5f;

                Vector3 targetPos = this.transform.position + new Vector3(xSpeed, 0f, zSpeed);
                Vector3 dir = targetPos - this.transform.position;
                dir.Normalize();
                this.transform.forward = dir;

                Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
                ChickenRigidbody.velocity = newVelocity;
            }
            else
            {
                this.transform.LookAt(target);
                ChickenRigidbody.velocity = transform.forward * 5;
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
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 1f);
            chickenSpawn.ants -= 1;
        }
    }
}
