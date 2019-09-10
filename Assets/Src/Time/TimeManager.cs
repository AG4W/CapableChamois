using UnityEngine;

using System.Collections;

public class TimeManager : MonoBehaviour
{
    static bool _inSlowMotion;

    void Start()
    {
        _inSlowMotion = false;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f * Time.timeScale;

        GlobalEvents.Subscribe(GlobalEvent.ToggleSlowMotion, (object[] args) => ToggleSlowMotion());
    }

    void ToggleSlowMotion()
    {
        _inSlowMotion = !_inSlowMotion;

        this.StopAllCoroutines();
        StartCoroutine(InterpolateTimeDilation(_inSlowMotion ? .2f : 1f, .33f));
    }
    IEnumerator InterpolateTimeDilation(float value, float duration)
    {
        float old = Time.timeScale;
        float t = 0f;

        while (t <= duration)
        {
            t += Time.fixedDeltaTime;

            Time.timeScale = Mathf.Lerp(old, value, Mathf.Pow(t / duration, 3));
            Time.fixedDeltaTime = .02f * Time.timeScale;
            
            yield return new WaitForEndOfFrame();
        }
    }
}
