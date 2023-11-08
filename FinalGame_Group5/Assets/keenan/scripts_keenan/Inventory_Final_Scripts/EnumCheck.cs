using System;
using UnityEngine;

namespace keenan.scripts_keenan.Inventory_Final_Scripts
{
    public class EnumCheck : MonoBehaviour
    {
        public enum StateEnum
        {
            State1,
            State2,
            State3
        }
        public StateEnum currentState = StateEnum.State1; // Initial state
        public int change = 0;
        private void Update()
        {
            if (change == 1)
            {
                ChangeState();
                
            }
        }

        // Function to update the state and display it
        public void ChangeState()
        {
            switch (currentState)
            {
                case StateEnum.State1:
                    currentState = StateEnum.State2;
                    break;
                case StateEnum.State2:
                    currentState = StateEnum.State3;
                    break;
                case StateEnum.State3:
                    currentState = StateEnum.State1;
                    break;
            }

            // Update the Text component to display the current state
            print(currentState);
            change = 0;
        }
    }
}
