using UnityEngine;
namespace LittleFishers.Fishing
{
    public class Waiting : IState
    {
        public float timeWaited;

        public Waiting(Fishing fishingController)
        {
        }

        public void OnEnter() { }
        public void OnExit() { }
        public void Tick()
        {
            timeWaited += Time.deltaTime;
        }
    }
}
