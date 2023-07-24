using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class BuildTowerBullet : MonoBehaviour
{
    private float speed = default;
    private Rigidbody bulletRigidbody = default;


    private void Awake()
    {
        speed = 20;
    }

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Chicken")
        {
            ChickenMove chickenMove_ = collider.GetComponent<ChickenMove>();
            if (chickenMove_ != null)
            {
                chickenMove_.Damage(10);
            }
        }
    }
}
