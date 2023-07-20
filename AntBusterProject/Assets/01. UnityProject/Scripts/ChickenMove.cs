using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChickenMove : MonoBehaviour
{
    private Rigidbody ChickenRigidbody = default;
    private Transform target = default;
    private int antMoveType = default;
    private int randomX = default;
    private int randomZ = default;
    private float time = default;
    private float moveTime = default;
    private bool chickenMoving = default;


    private void Awake()
    {
        ChickenRigidbody = GetComponent<Rigidbody>();
        target = FindObjectOfType<Destination>().transform;
        antMoveType = 0;
        randomX = 0;
        randomZ = 0;
        time = 0;
        moveTime = 1f;
        chickenMoving = false;
    }

    void Start()
    {

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
                float xSpeed = randomX;
                float zSpeed = randomZ;

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
}
