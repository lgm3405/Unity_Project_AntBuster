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
    public bool draggable = false;
    public int clickOrder = default;

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
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        level = 1;
        chickenCount = 0;
        level_ = 0;
        hp_ = 0;
        clickOrder = 1;
    }

    void Start()
    {
        Invoke("BuildTowerStart", 2f);
    }

    void Update()
    {
        
    }

    public void ClickToChicken()
    {
        //createTower.SetActive(false);
        chickenInfomation.SetActive(true);

        ObjectLevel.text = string.Format("Level : {0}", level_);
        ObjectHp.text = string.Format("HP : {0}", hp_);

    }

    public void BuildTowerStart()
    {
        createTower.SetActive(true);
    }
}
