using UnityEngine;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class PlayerMoveState : State
    {
        //[SerializeField] private PlayerMovementData movementData;        
        //[SerializeField] private HealthPoint healthPoint;
        [SerializeField, TitleGroup("Transforms")] private Transform PlayerTrans;
        [SerializeField, TitleGroup("Transforms")] private Transform leftFootTrans;
        [SerializeField, TitleGroup("Transforms")] private Transform rightFootTrans;
        [SerializeField, AssetsOnly, TitleGroup("FX")] private GameObject footDustFXPrefab;

        private MixerState<Vector2> moveAnimationState;

        private void Awake()
        {
            moveAnimationState = (MixerState<Vector2>)GetState("Move");
        }

        public override void Enter()
        {
            base.Enter();

            PlayMoveAnimation();

            //ServiceProvider.GameService.OnGameClear.AddListener(() => stateMachine.ChangeState<PlayerGameClearState>(this));            
            //healthPoint.OnDie.AddListener(() => stateMachine.ChangeState<PlayerDeadState>(this));
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            ApplyMovementValue();

            //gameActor.Rotator.SetRotationSpeed(0.1f);
            //gameActor.Rotator.RotateTowardMouseSmoothly();

            //moveAnimationState.Speed = movementData.Get().MoveSpeed;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void PlayMoveAnimation()
        {
            PlayAnimation("Move");
            PlayAnimation("Move_Gun");

            moveAnimationState.Events.Add(0.3f, () => SpawnFootDust(true));
            moveAnimationState.Events.Add(0.8f, () => SpawnFootDust(false));
        }

        private void ApplyMovementValue()
        {
            var movementValueConsideringPlayerRot = Quaternion.Euler(0.0f, PlayerTrans.transform.rotation.eulerAngles.y * -1, 0.0f) * Singleton.Input.MovementValue;
            var movementValueConsideringCameraRot = Quaternion.Euler(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f) * movementValueConsideringPlayerRot;
            var movementValue = new Vector2(movementValueConsideringCameraRot.x, movementValueConsideringCameraRot.z);
            moveAnimationState.Parameter = movementValue;
        }

        private void SpawnFootDust(bool isRight)
        {
            if (Singleton.Input.MovementValue == Vector3.zero) return;
            if (footDustFXPrefab == null) return;

            if (isRight == true)
            {
                Instantiate(footDustFXPrefab, rightFootTrans.position, Quaternion.identity);
            }
            else
            {
                Instantiate(footDustFXPrefab, leftFootTrans.position, Quaternion.identity);
            }
        }
    }
}