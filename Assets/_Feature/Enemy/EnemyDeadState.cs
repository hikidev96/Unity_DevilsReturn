using UnityEngine;

namespace DevilsReturn
{
    public class EnemyDeadState : State
    {
        [SerializeField] private GameObject deadFXPrefab;
        [SerializeField] private GameObject rootObject;

        public override void Enter()
        {
            base.Enter();

            //PlayAnimation("Dead");

            InstantitateDeadFX();
            DestroyRootObj();
            //Invoke("InstantitateDeadFX", 2.0f);
            //Invoke("DestroyRootObj", 2.0f);
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

        private void InstantitateDeadFX()
        {
            Instantiate(deadFXPrefab, this.transform.position + VectorHelper.ZeroExcept(y : 0.25f), Quaternion.identity);
        }

        private void DestroyRootObj()
        {
            Destroy(rootObject);
        }
    }
}
