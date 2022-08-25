using UnityEngine;

namespace DevilsReturn
{
    public class EnemyChaseState : State
    {
        public override void Enter()
        {
            base.Enter();

            PlayAnimation("Chase");
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
