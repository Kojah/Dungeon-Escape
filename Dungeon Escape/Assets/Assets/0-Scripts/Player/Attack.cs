using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool coolingDown = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (!coolingDown && hit != null)
        {
            hit.Damage(1);
            Debug.Log("hit!");
            coolingDown = true;
            StartCoroutine(attackCooldown());
        }
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        coolingDown = false;
    }
}
