using UnityEngine;
using Animancer;

namespace DevilsReturn
{
    public class EnemyAttackState : State
    {
        private EnemyAttack attack;
        private AnimancerState animationState;

        public override void Enter()
        {
            base.Enter();

            animationState = PlayAnimation(attack.Animation);
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

        public void Attack()
        {
            var overraped = Physics.OverlapSphere(this.transform.position + (this.transform.forward * attack.Range), 1.0f);

            for (int i = 0; i < overraped.Length; ++i)
            {
                var healthPoint = overraped[i].GetComponent<HealthPoint>();

                if (healthPoint != null && healthPoint.Faction == EFaction.Player)
                {
                    Debug.Log("Damage To Player");
                    healthPoint.Damage(new DamageData(attack.BaseDamage, this.transform.forward));
                }
            }
        }

        public void SetAttack(EnemyAttack attack)
        {
            this.attack = attack;
        }

        public void ToChaseState()
        {
            stateMachine.ChangeState<EnemyChaseState>(this);
        }
    }
}
