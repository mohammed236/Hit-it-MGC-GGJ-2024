using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2.0f;

    private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        StopShakeCamera();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = shakeAmplitude;
        noise.m_FrequencyGain = shakeFrequency;

        shakeTimer = shakeDuration;
    }
    public void StopShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;

        shakeTimer = 0;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                StopShakeCamera();
            }
        }
    }
}