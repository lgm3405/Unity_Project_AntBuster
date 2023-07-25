using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LongRangeTowerAttack : MonoBehaviour
{
    public GameObject bullet;

    private float shotsTime = default;
    private float shotsCoolTime = default;

    private void Awake()
    {
        shotsTime = 0;
        shotsCoolTime = 1f;
    }

    void Update()
    {
        if (shotsTime < shotsCoolTime)
        {
            shotsTime += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (GameManager.instance.isGameOver == true) { return; }

        if (collider.tag == "Chicken")
        {
            if (shotsTime >= shotsCoolTime)
            {
                transform.LookAt(collider.transform);
                shotsTime = 0;
                GameObject bullet_ = Instantiate(bullet, transform.position, transform.rotation);
                bullet.transform.LookAt(collider.transform);
            }
        }
    }
}
