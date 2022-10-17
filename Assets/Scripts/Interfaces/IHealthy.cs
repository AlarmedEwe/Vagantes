using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthy
{
    public static int health;

    void TakeDamage(int damage);
}
