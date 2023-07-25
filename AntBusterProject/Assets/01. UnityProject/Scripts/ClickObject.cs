using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public Camera getCamera;

    private RaycastHit hit;
    private GameObject obj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.isGameOver == true) { return; }

            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                obj = hit.collider.gameObject;

                if (objectName == ("LongRangeTower(Clone)"))
                {
                    Debug.Log("LongRangeTower");
                    //randomTower.enabled = true;
                }
                if (objectName == ("HeavyTower(Clone)"))
                {
                    Debug.Log("HeavyTower");
                }
                if (objectName == ("MachineGunTower(Clone)"))
                {
                    Debug.Log("MachineGunTower");
                }

                //if (objectName == ("Chicken(Clone)"))
                //{
                //    ChickenMove chickenMove_ = obj.GetComponent<ChickenMove>();
                //    level_ = ChickenMove.level;
                //    hp_ = ChickenMove.hp;
                //    GameManager.instance.level_ = level_;
                //    GameManager.instance.hp_ = hp_;
                //    Gamemanager.instance.clicktochicken();
                //}
            }
        }
    }
}
