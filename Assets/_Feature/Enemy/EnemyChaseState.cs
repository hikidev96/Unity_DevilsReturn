using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace DevilsReturn
{
    public class EnemyChaseState : State
    {
        [SerializeField] private AIPath aiPath;
        [SerializeField] private ScriptableTransform playerTransform;
        [SerializeField] private List<EnemyAttack> enemyAttacks;

        private EnemyAttack nextAttack;

        public override void Enter()
        {
            base.Enter();

            EnableMove();
            SelectNextAttackRandomly();
            PlayAnimation("Chase");
        }

        public override void Exit()
        {
            base.Exit();

            DisableMove();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            UpdateDestination();

            if (Vector3.Distance(this.transform.position, playerTransform.Get().position) <= nextAttack.Range)
            {
                stateMachine.GetState<EnemyAttackState>().SetAttack(nextAttack);    
                stateMachine.ChangeState<EnemyAttackState>(this);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public void ToDeadState()
        {
            stateMachine.ChangeState<EnemyDeadState>(this);
        }

        private void DisableMove()
        {
            aiPath.canMove = false;
        }

        private void EnableMove()
        {
            aiPath.canMove = true;
        }

        private void UpdateDestination()
        {
            aiPath.destination = playerTransform.Get().position;
        }

        private void SelectNextAttackRandomly()
        {
            nextAttack = enemyAttacks[Random.Range(0, enemyAttacks.Count)];
        }
    }
}