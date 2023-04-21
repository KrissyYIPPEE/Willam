using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAddons : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //sticking to first target
        if (targetHit)
            return;
        else
            targetHit = true;

        //projectile sticks
        rb.isKinematic = true;

        //projectile moves with target
        transform.SetParent(collision.transform);
    }
}
