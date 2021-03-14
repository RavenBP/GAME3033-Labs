using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health;

public class ZombieHealthComponent : HealthComponent
{
    private StateMachine ZombieStateMachine;

    // Start is called before the first frame update
    private void Awake()
    {
        ZombieStateMachine = GetComponent<StateMachine>();
    }

    public override void Destroy()
    {
        ZombieStateMachine.ChangeState(ZombieStateType.Dead);
    }
}
