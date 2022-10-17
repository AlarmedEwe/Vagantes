using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float Cooldown = 1f;
    [SerializeField]
    private int damage = 10;
    public int HitDistance = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IHealthy>(out var target))
        {
            target.TakeDamage(damage);
        }
    }
}
