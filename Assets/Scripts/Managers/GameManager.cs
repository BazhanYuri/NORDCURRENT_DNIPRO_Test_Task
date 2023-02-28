using System;
using UnityEngine;





namespace TanksBattle
{
    public enum CompletedType
    {
        Winned,
        Fail
    }


    public class GameManager : MonoBehaviour
    {
        public static event Action GamePlayStarted;
        public static event Action<CompletedType> GameCompleted;



        private void OnEnable()
        {
            ExitGame.ExitButtonPressed += Quit;
        }
        private void OnDisable()
        {
            ExitGame.ExitButtonPressed -= Quit;
        }


        private void Start()
        {
            GamePlayStarted?.Invoke();
            GameObject instance = GameObject.Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        }
        private void Quit()
        {
    
            Application.Quit();
        }
    }
}

