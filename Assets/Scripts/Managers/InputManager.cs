using System;
using UnityEngine;



namespace TanksBattle
{
    public enum ControlSide
    {
        Forward,
        Back,
        Left,
        Right
    }
    public class InputManager : MonoBehaviour
    {
        public static event Action<ControlSide> MoveButtonPressed;
        public static event Action Shoot;

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveButtonPressed?.Invoke(ControlSide.Forward);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveButtonPressed?.Invoke(ControlSide.Back);
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveButtonPressed?.Invoke(ControlSide.Left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                MoveButtonPressed?.Invoke(ControlSide.Right);
            }

            if (Input.GetMouseButtonDown(0))
                Shoot?.Invoke();
        }
    }
}

