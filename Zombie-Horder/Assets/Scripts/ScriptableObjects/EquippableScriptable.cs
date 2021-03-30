using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public abstract partial class EquippableScriptable : ItemScriptable
{
    public bool Equipped
    {
        get => m_Equipped;
        set
        {
            m_Equipped = value;
        }
    }
    private bool m_Equipped;

    public override void UseItem(PlayerController controller)
    {
        Equipped = !Equipped;
    }
}
