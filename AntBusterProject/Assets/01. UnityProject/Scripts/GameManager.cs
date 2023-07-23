using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int level = default;
    public int chickenCount = default;
    public GameObject createTower = default;
    public GameObject chickenInfomation = default;
    public Text ObjectLevel = default;
    public Text ObjectHp = default;
    public GameObject obj_ = default;

    public int hp_ = default;
    public int level_ = default;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }

        level = 1;
        chickenCount = 0;
        level_ = 0;
        hp_ = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClickToChicken()
    {
        createTower.SetActive(false);
        chickenInfomation.SetActive(true);

        ObjectLevel.text = string.Format("Level : {0}", level_);
        ObjectHp.text = string.Format("HP : {0}", hp_);

    }
}
