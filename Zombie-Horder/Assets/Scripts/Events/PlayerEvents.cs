using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Systems.Health;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void Invoke_OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }

    public delegate void OnHealthInitializedEvent(HealthComponent healthComponent);

    public static event OnHealthInitializedEvent OnHealthInitialized;

    public static void Invoke_OnHealthInitialized(HealthComponent healthComponent)
    {
        OnHealthInitialized?.Invoke(healthComponent);
    }
}
