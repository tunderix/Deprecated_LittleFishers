using UnityEngine;
using System;

namespace LittleFishers.Fishing
{
    public class Fishing
    {
        private StateMachine _stateMachine;
        private Fish _currentFish;
        public Fishing()
        {
            _stateMachine = new StateMachine();

            Activation activation = new Activation(this);
            _stateMachine.SetState(activation);

            Dependencies dependencies = new Dependencies(this);
            Start startState = new Start(this);
            Waiting waiting = new Waiting(this);
            FishOn fishOn = new FishOn(this);
            Resolution resolution = new Resolution(this);

            At(dependencies, activation, PlayerActivatedFishing());
            At(startState, dependencies, DefaultCondition());
            At(waiting, startState, DefaultCondition());
            At(fishOn, waiting, WaitedEnough());
            At(resolution, fishOn, FishingDone());

            Func<bool> DefaultCondition() => () => true;
            Func<bool> PlayerActivatedFishing() => () => true;
            Func<bool> WaitedEnough() => () => waiting.timeWaited > 2f;
            Func<bool> FishingDone() => () => true;
        }

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        public void Tick()
        {
            _stateMachine.Tick();
        }
    }
}
