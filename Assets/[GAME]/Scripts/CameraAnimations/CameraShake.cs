using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineCamera cinemachineCamera;
    [SerializeField] private float _shakeIntensity = 1f;
    [SerializeField] private float _shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    private void OnEnable()
    {
        Actions.ButtonPressed += ShakeCamera;
    }

    private void OnDisable()
    {
        Actions.ButtonPressed -= ShakeCamera;
    }

    private void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
        cbmcp = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StopShake();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
                StopShake();
        }
    }

    public void ShakeCamera()
    {
        cbmcp.AmplitudeGain = _shakeIntensity;

        timer = _shakeTime;
    }

    public void StopShake()
    {
        cbmcp.AmplitudeGain = 0;

        timer = 0;
    }

}
