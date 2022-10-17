using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    private int currentAmmo = 10;
    private int maxAmmo = 10;
    private int inventoryAmmo = 100;
    [SerializeField]
    private TextMeshProUGUI display;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        display.text = $"{currentAmmo}/{inventoryAmmo}";
    }

    public void Shoot()
    {
        currentAmmo -= 1;
        if (currentAmmo <= 0)
            Reload();
    }

    public void Reload()
    {
        inventoryAmmo -= maxAmmo;
        currentAmmo = maxAmmo;
    }
}
