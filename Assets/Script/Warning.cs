using UnityEngine;

public class WarningPulse : MonoBehaviour
{
    private float pulseSpeed = 4f;
    private float pulseScale = 0.2f;
    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseScale;
        transform.localScale = baseScale * scale;
    }
}
