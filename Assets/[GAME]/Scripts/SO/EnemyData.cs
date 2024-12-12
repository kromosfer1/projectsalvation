using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Movement Data")]
    public float BaseMovementSpeed = 2f;

    [Header("Health Data")]
    public int HitPoints = 2;

    [Header("Economy Data")]
    public int CurrencyWorth = 1;
}
