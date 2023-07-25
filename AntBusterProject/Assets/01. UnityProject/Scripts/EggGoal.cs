using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGoal : MonoBehaviour
{
    private GameObject thisEgg;
    private GameObject chickenCount;

    private void Awake()
    {
        chickenCount = GameObject.Find("StartTunnul");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance.isGameOver == true) { return; }

        if (collider.tag == "Chicken")
        {
            thisEgg = collider.gameObject;
            if (thisEgg.GetComponent<ChickenMove>().getEgg == false) { return; }

            thisEgg.SetActive(false);
            Destroy(thisEgg, 1f);
            GameManager.instance.eggLife -= 1;
            chickenCount.GetComponent<ChickenSpawn>().ants -= 1;
            if (GameManager.instance.eggLife <= 0)
            {
                GameManager.instance.isGameOver = true;
                GameManager.instance.EndGame();
            }
        }
    }
}
