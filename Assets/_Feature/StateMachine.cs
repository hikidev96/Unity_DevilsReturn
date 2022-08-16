using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class StateMachine : BaseMonoBehaviour
    {
        [SerializeField] private State startState;

        private List<State> states = new List<State>();
        protected State currentState;

        protected virtual void Awake()
        {
            for (int i = 0; i < this.transform.childCount; ++i)
            {
                states.Add(this.transform.GetChild(i).GetComponent<State>());
            }
        }

        protected virtual void Start()
        {
            currentState = startState;
            startState?.Enter();
        }

        protected virtual void Update()
        {
            currentState?.LogicUpdate();
        }

        protected virtual void FixedUpdate()
        {
            currentState?.PhysicsUpdate();
        }

        public void ChangeState<T>(State current) where T : State
        {
            if (current != this.currentState)
            {
                return;
            }

            currentState?.Exit();

            var to = GetState<T>();

            if (to != null)
            {
                to?.Enter();
                currentState = to;
            }                        
        }

        protected void SetStartState(State startState)
        {
            this.startState = startState;
        }

        private State GetState<T>()
        {
            for (int i = 0; i < states.Count; ++i)
            {
                if (typeof(T) == states[i].GetType())
                {
                    return states[i];
                }
            }

            return null;
        }
    }
}
