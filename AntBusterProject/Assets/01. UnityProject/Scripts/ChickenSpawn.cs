using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject ChickenPrefab;

    private int antsMax = default;
    private int ants = default;
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
            if (ants < 6)
            {
                GameObject ant = Instantiate(ChickenPrefab, transform.position, transform.rotation);
                ants += 1;
                time = 0;
            }
            else
            {
                time = 0;
            }
        }
    }
}
