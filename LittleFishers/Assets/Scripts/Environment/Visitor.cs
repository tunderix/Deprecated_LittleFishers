using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.Environment
{
    public class Visitor : MonoBehaviour
    {
        private List<Visitable> currentVisits;

        private void Awake()
        {
            currentVisits = new List<Visitable>();
        }

        public void Arrived(Visitable to)
        {
            currentVisits.Add(to);
        }

        public void Left(Visitable from)
        {
            currentVisits.Remove(from);
        }
    }
}
