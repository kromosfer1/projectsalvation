using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int _hitPoints = 2;

    public void TakeDamage(int dmg)
    {
        _hitPoints -= dmg;

        if (_hitPoints <= 0)
        {
            Actions.OnEnemyDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
