using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleFishers.Environment
{
    public class Visitable : MonoBehaviour
    {

        public delegate void VisitorArrived();
        public delegate void VisitorLeft();
        public VisitorArrived OnVisitorArrived;
        public VisitorLeft OnVisitorLeft;

        void OnTriggerEnter(Collider other)
        {
            Visitor visitor = other.GetComponent<Visitor>();
            if (visitor != null)
            {
                visitor.Arrived(this);
                VisitorVisiting(visitor);
            }
        }

        void OnTriggerStay(Collider other)
        {

        }

        void OnTriggerExit(Collider other)
        {
            Visitor visitor = other.GetComponent<Visitor>();
            if (visitor != null)
            {
                visitor.Left(this);
                VisitorExit(visitor);
            }
        }

        private void VisitorVisiting(Visitor visitor)
        {
            OnVisitorArrived();
        }

        private void VisitorExit(Visitor visitor)
        {
            OnVisitorLeft();
        }
    }
}
