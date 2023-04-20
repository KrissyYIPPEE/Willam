using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation (when placeholder is removed)
        //Detect enemies in hitbox
    }
    // GO TO BRAKEYS VIDEO ON MELEE COMBAT
}
