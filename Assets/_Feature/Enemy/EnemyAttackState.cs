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

        public void Attack()
        {
            if (attack == null) return;

            switch (attack.AttackType)
            {
                case EEnemyAttackType.Melee:
                    MeleeAttack();
                    break;
                case EEnemyAttackType.Projectile:
                    ProjectileAttack();
                    break;
            }
        }

        private void MeleeAttack()
        {
            var overraped = Physics.OverlapSphere(this.transform.position + (this.transform.forward * attack.Range), 1.0f);

            for (int i = 0; i < overraped.Length; ++i)
            {
                var healthPoint = overraped[i].GetComponent<HealthPoint>();

                if (healthPoint != null && healthPoint.Faction == EFaction.Player)
                {                    
                    healthPoint.Damage(new DamageData(attack.BaseDamage, this.transform.forward));
                }
            }
        }

        private void ProjectileAttack()
        {
            var projectileObj = Instantiate(attack.ProjectilePrefab, attack.FirePoint.position, Quaternion.identity);            
            projectileObj.transform.forward = VectorHelper.GetExceptYFrom(attack.FirePoint.forward);

            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.SetDamage(attack.BaseDamage);    

            var projectileFireFXObj = Instantiate(attack.ProjectileFirePrefab, attack.FirePoint.position, Quaternion.identity);
            projectileFireFXObj.transform.forward = VectorHelper.GetExceptYFrom(attack.FirePoint.forward);
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
