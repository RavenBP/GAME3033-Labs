using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private GameObject FollowTarget;
    private float AttackRange = 2.0f;

    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");


    public ZombieAttackState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }

    public override void Start()
    {
        //base.Start();

        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, 0.0f);
        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, true);
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        // TODO: Add damage to object
    }

    public override void Update()
    {
        //base.Update();

        OwnerZombie.transform.LookAt(FollowTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position);

        if (distanceBetween > AttackRange)
        {
            StateMachine.ChangeState(ZombieStateType.Follow);
        }

        // TODO: Zombie health < 0 die
    }

    public override void Exit()
    {
        base.Exit();

        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, false);
    }
}
