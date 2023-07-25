using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class LongRangeTowerBullet : MonoBehaviour
{
    private float speed = default;
    private Rigidbody bulletRigid = default;

    private void Awake()
    {
        speed = 30f;
    }

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * speed;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Chicken")
        {
            ChickenMove chickenMove_ = collider.GetComponent<ChickenMove>();
            if (chickenMove_ != null)
            {
                chickenMove_.Damage(8);
            }
        }
    }
}