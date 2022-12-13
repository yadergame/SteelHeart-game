using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachinePlayer
{
    public abstract class State
    {
        protected Player player;
        protected StateMachine stateMachine; 
        public State(StateMachine stateMachine, Player player)
        {
            this.stateMachine = stateMachine;
            this.player = player;
        } 

        public virtual void Enter()
        {            
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }
    }

}