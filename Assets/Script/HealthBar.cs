using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageHealth;
    [SerializeField] private float delta;
    private float healthvalue;
    private float currentHealth;

    private void Update()
    {

        currentHealth = Health.Instance.CurrentHealth / 100;
        if (currentHealth > healthvalue)
            healthvalue += delta;
        if (currentHealth < healthvalue)
            healthvalue -= delta;
        if (Mathf.Abs(currentHealth - healthvalue) < delta)
            healthvalue = currentHealth;
        imageHealth.fillAmount = healthvalue;
    }

}
