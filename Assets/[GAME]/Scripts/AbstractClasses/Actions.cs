using System;
using UnityEngine;

public static class Actions
{
    #region ENEMIES
    public static Action OnEnemyDestroyed;
    public static Action OnPlaneDestroyed;
    public static Action OnRocketHit;
    public static Action OnBirdHit;
    public static Action OnPlaneHit;
    public static Action<Transform, float> UpdateEnemySpeed;
    public static Action<Transform> ResetEnemySpeed;
    #endregion

    #region PLAYER
    public static Action<int> DamageTaken;
    public static Action OnDamageTaken;
    public static Action OnPlayerDeath;
    public static Action<float> ImmunityActive;
    #endregion

    #region TIME
    public static Action On30SecUp;
    #endregion

    #region SOUND
    public static Action ButtonPressed;
    #endregion
}
