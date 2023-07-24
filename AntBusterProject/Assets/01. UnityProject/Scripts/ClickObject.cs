using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public Camera getCamera;
    public int level_;
    public int hp_;
    public Image randomTower;

    private RaycastHit hit;
    private GameObject obj;
    
    private void Awake()
    {
        randomTower = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                string objectName = hit.collider.gameObject.name;
                obj = hit.collider.gameObject;

                if (objectName == ("tower(Clone)"))
                {
                    Debug.Log("타워를 클릭했다");
                    //randomTower.enabled = true;
                }
                if (objectName == ("Chicken(Clone)"))
                {
                    ChickenMove chickenMove_ = obj.GetComponent<ChickenMove>();
                    level_ = ChickenMove.level;
                    hp_ = ChickenMove.hp;
                    GameManager.instance.level_ = level_;
                    GameManager.instance.hp_ = hp_;
                    GameManager.instance.ClickToChicken();
                }
            }
        }
    }
}
