using NUnit.Framework;
using System.Collections;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTests
{
    // Comprobar que Start() inicializa la vida al máximo
    [UnityTest]
    public IEnumerator Health_InitializesWithMaxHealthOnStart()
    {
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        health.MaxHealth = 80f;

        // Esperamos un frame para que se ejecute el Start() de Health.cs
        yield return null;

        Assert.AreEqual(80f, health.CurrentHealth);
    }

    // Comprobar que el evento OnDie se dispara al morir
    [UnityTest]
    public IEnumerator OnDie_IsCalledWhenHealthReachesZero()
    {
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        bool died = false;

        // Nos suscribimos al evento de tu script
        health.OnDie += () => died = true;

        yield return null; // Esperar inicialización

        health.TakeDamage(1000f, null); // Daño letal

        Assert.IsTrue(died);
    }


    //Comprobar que CanPickup devuelve falso si la vida está llena
    [UnityTest]
    public IEnumerator CanPickup_ReturnsFalseAtFullHealth()
    {
        GameObject go = new GameObject();
        Health health = go.AddComponent<Health>();
        health.MaxHealth = 100f;

        yield return null; // Esperar a que Start ponga CurrentHealth = MaxHealth

        Assert.IsFalse(health.CanPickup());
    }
}
