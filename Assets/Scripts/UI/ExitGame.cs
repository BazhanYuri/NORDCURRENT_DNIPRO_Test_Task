using System;
using UnityEngine;
using UnityEngine.UI;



namespace TanksBattle
{
    public class ExitGame : MonoBehaviour
    {
        [SerializeField] private Button _button;


        public static event Action ExitButtonPressed;



        private void OnEnable()
        {
            _button.onClick.AddListener(ExitPressed);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }
        private void ExitPressed()
        {
            ExitButtonPressed?.Invoke();
        }
    }
}

