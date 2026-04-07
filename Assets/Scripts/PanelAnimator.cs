using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PanelAnimator : MonoBehaviour
{
    [SerializeField] private float _duration = 0.3f;

    private CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        StopAllCoroutines();
        gameObject.SetActive(true);
        StartCoroutine(Fade(0f, 1f));
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(1f, 0f, disableOnEnd: true));
    }

    private IEnumerator Fade(float from, float to, bool disableOnEnd = false)
    {
        _canvasGroup.alpha = from;
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / _duration);
            yield return null;
        }

        _canvasGroup.alpha = to;

        if (disableOnEnd)
            gameObject.SetActive(false);
    }
}