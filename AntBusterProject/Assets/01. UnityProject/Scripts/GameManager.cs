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
    public GameObject gameOver = default;
    public Text gameLevel = default;
    public Text gameMoney = default;
    public Text towerCost = default;
    public int level = default;
    public int chickenCount = default;
    public bool draggable = false;
    public bool isGameOver = false;
    public int money = default;
    public int randomTowerPay = default;
    public int towerCount = default;
    public int eggLife = default;

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
        money = 100;
        randomTowerPay = 50;
        towerCount = 0;
        eggLife = 6;
    }

    void Update()
    {
        if (isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
        else if (isGameOver == false)
        {
            gameLevel.text = string.Format("Level : {0}", level);
            gameMoney.text = string.Format("Money : {0}", money);
            towerCost.text = string.Format("Cost : {0}", randomTowerPay);
        }
    }

    public void EndGame()
    {
        gameOver.SetActive(true);
    }

    //public void ClickToChicken()
    //{
    //    //createTower.SetActive(false);
    //    chickenInfomation.SetActive(true);

    //    ObjectLevel.text = string.Format("Level : {0}", level_);
    //    ObjectHp.text = string.Format("HP : {0}", hp_);

    //}
}
