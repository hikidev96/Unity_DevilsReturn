using UnityEngine;

namespace DevilsReturn
{
    public class EnemyIdleState : State
    {
        [SerializeField] private MainAlphaFader mainAlphaFader;
        
        private void Start()
        {
            mainAlphaFader.FadeIn();
        }

        public override void Enter()
        {
            base.Enter();

            PlayAnimation("Idle");
            Invoke("ToChaseState", 1.0f);
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

        public void ToDeadState()
        {
            stateMachine.ChangeState<EnemyDeadState>(this);
        }

        public void ToChaseState()
        {
            stateMachine.ChangeState<EnemyChaseState>(this);
        }
    }
}
