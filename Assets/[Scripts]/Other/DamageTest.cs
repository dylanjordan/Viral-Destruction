using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    private float attackDelay = 1.0f;
    private bool canAttack = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
            StartCoroutine(DamagePlayer());
    }

    private IEnumerator DamagePlayer()
    {
        canAttack = false;
        FirstPersonController.OnTakeDamage(15);
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}