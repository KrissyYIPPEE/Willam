using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Throwing : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectThrowing;
    public LayerMask whatIsEnemy;
    RaycastHit rayHit;
    public TextMeshProUGUI text;

    [Header("Settings")]
    public int totalThrows = 1;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }

        //setText
        text.SetText("" + totalThrows);
    }

    private void Throw()
    {
        readyToThrow = false;

        //Audio
        FindObjectOfType<AudioManager>().Play("Shuriken");

        //instatiating the object
        GameObject projectile = Instantiate(objectThrowing, attackPoint.position, cam.rotation);

        //get rb component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //calculating direction
        Vector3 forceDirection = cam.transform.forward;

        if(Physics.Raycast(cam.position, cam.forward, out rayHit, 500f))
        {
            forceDirection = (rayHit.point - attackPoint.position).normalized;
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<AllHealth>().TakeDamage(10);
        }

        //adding force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //throw cooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        totalThrows = 1;
        readyToThrow = true;
    }
}
