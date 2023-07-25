using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTowerBullet : MonoBehaviour
{
    private float speed = default;
    private Rigidbody bulletRigid = default;

    private void Awake()
    {
        speed = 40f;
    }

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * speed;
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance.isGameOver == true) { return; }

        if (collider.tag == "Chicken")
        {
            ChickenMove chickenMove_ = collider.GetComponent<ChickenMove>();
            if (chickenMove_ != null)
            {
                chickenMove_.Damage(3);
            }
        }
    }
}
