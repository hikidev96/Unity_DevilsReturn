using UnityEngine;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class PlayerMoveState : State
    {
        //[SerializeField] private PlayerMovementData movementData;        
        //[SerializeField] private HealthPoint healthPoint;
        [SerializeField, TitleGroup("Base")] Rotator playerRotator;
        [SerializeField, TitleGroup("Detail")] float moveSpeed = 1.0f;
        [SerializeField, TitleGroup("Transforms")] private Transform PlayerTrans;
        [SerializeField, TitleGroup("Transforms")] private Transform leftFootTrans;
        [SerializeField, TitleGroup("Transforms")] private Transform rightFootTrans;
        [SerializeField, AssetsOnly, TitleGroup("FX")] private GameObject footDustFXPrefab;

        private MixerState<Vector2> moveAnimationState;

        private void Awake()
        {
            moveAnimationState = (MixerState<Vector2>)GetState("Move");
        }

        private void Start()
        {
            PlayAnimation("IdleOnlyUpper");
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

            playerRotator.SetRotationSpeed(0.1f);
            playerRotator.RotateTowardMouseDirectly();

            moveAnimationState.Speed = moveSpeed;
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
            PlayAnimation("Move", moveSpeed);

            moveAnimationState.Events.Add(0.3f, () => SpawnFootDust(true));
            moveAnimationState.Events.Add(0.8f, () => SpawnFootDust(false));
        }

        public void PlayFireAnimation()
        {
            PlayAnimation("Fire", 3.0f);
        }

        public void ToDeadState()
        {
            stateMachine.ChangeState<PlayerDeadState>(this);
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