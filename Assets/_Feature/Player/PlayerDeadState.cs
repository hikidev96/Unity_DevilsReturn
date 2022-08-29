using UnityEngine;

namespace DevilsReturn
{
    public class PlayerDeadState : State
    {
        public override void Enter()
        {
            base.Enter();

            PlayAnimation("Dead");
            Invoke("OpenGameOverMenu", 1.5f);
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

        private void OpenGameOverMenu()
        {
            Singleton.UI.InstantiateGameOverMenuAndOpen();
        }
    }
}