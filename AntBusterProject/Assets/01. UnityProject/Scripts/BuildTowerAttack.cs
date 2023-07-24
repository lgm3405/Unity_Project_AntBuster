using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildTowerAttack : MonoBehaviour
{
    public GameObject buildTowerBulletPrefab;

    private Transform target = default;
    private float shotsTime = default;
    private float shotsCoolTime = default;
    private BuildTowerAttack buildTowerAttack_;

    private void Awake()
    {
        buildTowerAttack_ = gameObject.GetComponent<BuildTowerAttack>();
        shotsTime = 0;
        shotsCoolTime = 1;
        buildTowerAttack_.enabled = false;
    }

    void Start()
    {
        
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
        if (collider.tag == "Chicken")
        {
            if (shotsTime >= shotsCoolTime)
            {
                transform.LookAt(collider.transform);
                shotsTime = 0;
                GameObject bullet = Instantiate(buildTowerBulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(collider.transform);
            }
        }
    }
}
