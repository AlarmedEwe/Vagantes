using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float range;

    [SerializeField] private new Camera camera;
    [SerializeField] private ParticleSystem flash;
    [SerializeField] private EGunType type = EGunType.Manual;
    [SerializeField] private AmmoManager ammo;

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
    }

    private void CheckShoot()
    {
        switch (type)
        {
            case EGunType.Manual:
                if (Input.GetButtonDown("Fire1"))
                    Shoot();

                break;
            case EGunType.Automatic:
            case EGunType.SemiAutomatic:
            default:
                if (Input.GetAxisRaw("Fire1") != 0)
                    Shoot();

                break;
        }
    }

    private void Shoot()
    {
        flash.Play();
        ammo.Shoot();

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (target is not null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
