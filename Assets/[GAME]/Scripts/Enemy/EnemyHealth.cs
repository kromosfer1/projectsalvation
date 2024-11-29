using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]    
    [SerializeField] private EnemyData _enemyData;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        _enemyData.HitPoints -= dmg;

        if (_enemyData.HitPoints <= 0 && !isDestroyed)
        {
            Actions.OnEnemyDestroyed?.Invoke();
            CurrencyManager.main.IncreaseCurrency(_enemyData.CurrencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
