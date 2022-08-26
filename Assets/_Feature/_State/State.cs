using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [System.Serializable]
    public class Animation
    {
        [SerializeField] private string animationID;
        [SerializeField] private int layerIndex;
        [SerializeField] private bool useAvatarMask;
        [SerializeField, ShowIf("@useAvatarMask==true")] private AvatarMask avatarMask;
        [SerializeReference] private ITransition animation;

        public string AnimationID => animationID;
        public int LayerIndex => layerIndex;
        public bool UseAvatarMask => useAvatarMask;
        public AvatarMask AvatarMask => avatarMask;
        public ITransition AnimationClip => animation;
    }

    public class State : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Base")] private List<Animation> animations;
        [SerializeField, TitleGroup("Base")] protected StateMachine stateMachine;
        [SerializeField, TitleGroup("Base")] private AnimancerComponent animancer;
        [SerializeField, TitleGroup("Event")] private UnityEvent onEnter;

        public virtual void Enter()
        {
            onEnter?.Invoke();
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }        

        public AnimancerState GetState(string animationID)
        {
            return animancer.States.GetOrCreate(GetAnimation(animationID).AnimationClip);
        }

        public AnimancerState PlayAnimation(string animationID, float speed = 1.0f)
        {
            var animation = GetAnimation(animationID);
            var layer = animancer.Layers[animation.LayerIndex];

            if (animation.UseAvatarMask == true)
            {
                layer.SetMask(animation.AvatarMask);
            }

            var result = layer.Play(animation.AnimationClip, fadeDuration: 0.2f);
            result.NormalizedTime = 0.0f;
            result.Speed = speed;

            return result;
        }

        public AnimancerState PlayAnimation(ITransition animation, float speed = 1.0f)
        {
            var result = animancer.Play(animation, fadeDuration: 0.2f);
            result.NormalizedTime = 0.0f;
            result.Speed = speed;

            return result;
        }

        private Animation GetAnimation(string animationID)
        {
            for (int i = 0; i < animations.Count; ++i)
            {
                if (animations[i].AnimationID == animationID)
                {
                    return animations[i];
                }
            }

            Debug.LogError($"Wrong AnimationID : {animationID}");

            return null;
        }
    }
}
