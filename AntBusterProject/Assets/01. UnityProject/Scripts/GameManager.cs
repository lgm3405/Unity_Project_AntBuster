using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject createTower = default;
    public Text gameLevel = default;
    public Text gameMoney = default;
    public Text towerCost = default;
    public int level = default;
    public int chickenCount = default;
    public bool draggable = false;
    public int money = default;
    public int randomTowerPay = default;
    public int towerCount = default;

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
        money = 100;
        randomTowerPay = 50;
        towerCount = 0;
    }

    void Update()
    {
        gameLevel.text = string.Format("Level : {0}", level);
        gameMoney.text = string.Format("Money : {0}", money);
        towerCost.text = string.Format("Cost : {0}", randomTowerPay);
    }

    //public void ClickToChicken()
    //{
    //    //createTower.SetActive(false);
    //    chickenInfomation.SetActive(true);

    //    ObjectLevel.text = string.Format("Level : {0}", level_);
    //    ObjectHp.text = string.Format("HP : {0}", hp_);

    //}
}
