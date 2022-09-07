using UnityEngine;
using Animancer;

namespace DevilsReturn
{
    public class EnemyAttackState : State
    {
        private EnemyAttack attack;

        public override void Enter()
        {
            base.Enter();

            PlayAnimation(attack.Animation);
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

        public void SetAttack(EnemyAttack attack)
        {
            this.attack = attack;
        }

        public void ToChaseState()
        {
            stateMachine.ChangeState<EnemyChaseState>(this);
        }

        public void ToDeadState()
        {
            stateMachine.ChangeState<EnemyDeadState>(this);
        }
    }
}
