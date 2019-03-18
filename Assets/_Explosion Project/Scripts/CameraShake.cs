using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance = null;

    public AnimationCurve m_MagnitudeCurve;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ShakeOnce(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Debug.Log("Shaking...");
        Vector3 originalPosition = transform.position;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            Vector3 position = Random.insideUnitSphere * (magnitude * m_MagnitudeCurve.Evaluate(elapsedTime / duration)) * Time.deltaTime;

            transform.position = originalPosition + position;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
        Debug.Log("End shake");
    }
}