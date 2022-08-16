using System.Collections.Generic;
using UnityEngine;
using Animancer;

namespace SOD
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AnimancerComponent))]
    public class IKHandler : MonoBehaviour
    {
        [SerializeField] private List<IKTarget> IKTargets;

        private AnimancerComponent animancer;

        private void Awake()
        {
            animancer = GetComponent<AnimancerComponent>();

            animancer.Layers[0].ApplyAnimatorIK = true;
        }
        
        private void OnAnimatorIK(int layerIndex)
        {
            for (int i = 0; i < IKTargets.Count; ++i)
            {
                IKTargets[i].UpdateAnimatorIK(animancer.Animator);
            }            
        }
    }
}