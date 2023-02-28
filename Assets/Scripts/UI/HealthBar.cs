using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



namespace TanksBattle
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Damagable _damagable;
        [SerializeField] private Image _healthBar;





        private void OnEnable()
        {
            _damagable.HealthUpdated += UpdateVisual;
        }
        private void OnDisable()
        {
            _damagable.HealthUpdated -= UpdateVisual;
        }

        private void UpdateVisual(float percentage)
        {
            _healthBar.DOSmoothRewind();
            _healthBar.DOFillAmount(percentage, 0.1f);
        }

    }
}

