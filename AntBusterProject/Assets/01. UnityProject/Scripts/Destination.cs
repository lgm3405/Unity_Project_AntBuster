using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public GameObject[] eggs = new GameObject[6];

    private GameObject thisEgg;
    private int eggCount = default;
    private bool[] eggCheck = new bool[6];

    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            eggCheck[i] = true;
        }

        eggCount = 6;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance.isGameOver == true) { return; }

        if (collider.tag == "Chicken")
        {
            if (eggCount > 0)
            {
                thisEgg = collider.gameObject;
                if (thisEgg.GetComponent<ChickenMove>().getEgg == true) { return; }

                thisEgg.GetComponent<ChickenMove>().getEgg = true;
                thisEgg.GetComponent<ChickenMove>().EggOn();

                for (int i = 0; i < 6; i++)
                {
                    if (eggCheck[i] == true)
                    {
                        eggs[i].SetActive(false);
                        eggCheck[i] = false;
                        eggCount -= 1;
                        break;
                    }
                }
            }
        }
    }

    public void EggReturn()
    {
        for (int i = 0; i < 6; i++)
        {
            if (eggCheck[i] == false)
            {
                eggs[i].SetActive(true);
                eggCheck[i] = true;
                eggCount += 1;
                break;
            }
        }
    }
}
