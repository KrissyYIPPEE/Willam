using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int totalSwings = 1;
    public float swingCooldown;
    bool readyToSwing;

    public LayerMask whatIsEnemy;
    public TextMeshProUGUI text;

    private void Start()
    {
        readyToSwing = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToSwing && totalSwings > 0)
        {
            Attack();
        }

        //setText
        text.SetText("");
    }

    void Attack()
    {
        readyToSwing = false;

        //Play attack animation (when placeholder is removed check back on Brakeys tutorial)


        //Detect enemies in hitbox
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, whatIsEnemy);

        //Apply damage
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<AllHealth>().TakeDamage(20);
        }

        totalSwings--;

        //Swing cooldown
        Invoke(nameof(Cooldown), swingCooldown);
    }

    void Cooldown()
    {
        totalSwings = 1;
        readyToSwing = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
