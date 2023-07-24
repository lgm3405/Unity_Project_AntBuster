using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject ChickenPrefab;
    public int ants = default;

    private int antsMax = default;
    private float time = default;
    private float spawnTime = default;


    private void Awake()
    {
        antsMax = 6;          // 필드에 나오는 개미 최대 수
        ants = 0;             // 현재 필드에 나와있는 개미 수
        time = 0;             // 체크 할 실제 시간값
        spawnTime = 2f;       // 개미 리스폰되는 시간
    }

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            if (ants < antsMax)
            {
                GameObject ant = Instantiate(ChickenPrefab, transform.position, transform.rotation);
                ants += 1;
                GameManager.instance.chickenCount += 1;
                if (GameManager.instance.chickenCount >= 18)
                {
                    GameManager.instance.level += 1;
                    GameManager.instance.chickenCount = 0;
                }

                time = 0;
            }
            else
            {
                time = 0;
            }
        }
    }
}
