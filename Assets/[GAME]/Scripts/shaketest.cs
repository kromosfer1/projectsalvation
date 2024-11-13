using UnityEngine;

public class shaketest : MonoBehaviour
{
    public void ShakeTest()
    {
        Actions.ButtonPressed?.Invoke();
    }
}
