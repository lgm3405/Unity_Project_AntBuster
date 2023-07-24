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
        antsMax = 6;          // �ʵ忡 ������ ���� �ִ� ��
        ants = 0;             // ���� �ʵ忡 �����ִ� ���� ��
        time = 0;             // üũ �� ���� �ð���
        spawnTime = 2f;       // ���� �������Ǵ� �ð�
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
