using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.FPS.Game;

public class EditModeTests
{
    //Comprobar que la curación no sobrepasa el máximo
    [Test]
    public void Heal_DoesNotExceedMaxHealth()
    {
        // Setup
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        health.MaxHealth = 100f;
        health.CurrentHealth = 90f;

        // Ejecución
        health.Heal(50f);

        // Verificación
        Assert.AreEqual(100f, health.CurrentHealth);
    }

    //Comprobar que la invencibilidad funciona
    [Test]
    public void TakeDamage_DoesNothingIfInvincible()
    {
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        health.MaxHealth = 100f;
        health.CurrentHealth = 100f;
        health.Invincible = true;

        health.TakeDamage(50f, null);

        Assert.AreEqual(100f, health.CurrentHealth);
    }

    //Comprobar si el estado crítico se detecta correctamente
    [Test]
    public void IsCritical_ReturnsTrueWhenHealthIsLow()
    {
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        health.MaxHealth = 100f;
        health.CriticalHealthRatio = 0.3f; // 30%

        health.CurrentHealth = 20f; // Está por debajo del 30%

        Assert.IsTrue(health.IsCritical());
    }
}
