using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Pathfinding;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class EnemyChaseState : State
    {
        [SerializeField, TitleGroup("Ai")] private AIPath aiPath;
        [SerializeField, TitleGroup("Ai")] private ScriptableTransform playerTransform;
        [SerializeField, TitleGroup("Ai")] private List<EnemyAttack> enemyAttacks;
        [SerializeField, TitleGroup("Base")] private MoveData moveData;

        private EnemyAttack nextAttack;
        private AnimancerState animancerState;
        private Coroutine selectNextAttackRandomlyCoroutine;

        public override void Enter()
        {
            base.Enter();

            EnableMove();

            selectNextAttackRandomlyCoroutine = StartCoroutine(SelectNextAttackRandomly());
            animancerState = PlayAnimation("Chase");
        }

        public override void Exit()
        {
            base.Exit();

            StopCoroutine(selectNextAttackRandomlyCoroutine);
            DisableMove();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            UpdateDestination();
            aiPath.maxSpeed = moveData.MoveSpeed;
            animancerState.Speed = moveData.MoveSpeed / 3.0f;
            if (nextAttack != null && Vector3.Distance(this.transform.position, playerTransform.Get().position) <= nextAttack.Range)
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

        private IEnumerator SelectNextAttackRandomly()
        {
            while (true)
            {
                nextAttack = enemyAttacks[Random.Range(0, enemyAttacks.Count)];

                if (nextAttack.IsOverCoolTime == false)
                {
                    nextAttack = null;
                }

                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}