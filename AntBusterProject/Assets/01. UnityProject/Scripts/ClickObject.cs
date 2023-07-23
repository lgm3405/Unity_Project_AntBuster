using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public Camera getCamera;
    public int level_;
    public int hp_;

    private RaycastHit hit;
    private GameObject obj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                obj = hit.collider.gameObject;

                if (objectName == ("Chicken(Clone)"))
                {

                    //level_ = GameObject.Find("Chicken(Clone)").GetComponent<ChickenSpawn>().level;
                    //hp_ = GameObject.Find("Chicken(Clone)").GetComponent<ChickenSpawn>().hp;
                    //GameManager.instance.level_ = level_;
                    //GameManager.instance.hp_ = hp_;
                    //GameManager.instance.ClickToChicken();
                }
            }
        }
    }
}
