using UnityEngine;

namespace DevilsReturn
{
    public class EnemyIdleState : State
    {
        public override void Enter()
        {
            base.Enter();

            PlayAnimation("Idle");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
