using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : ScriptableObject
{
    [Header("References")]
    public LayerMask EnemyMask;
    public GameObject BulletPrefab;


    [Header("Attributes")]
    public float TargetingRange = 5f;
    public float RotationSpeed = 5f;
    public float Bps = 1f; // Bullets Per Second
}
