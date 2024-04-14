using UnityEngine;
using MagicTween;
using CustomInspector;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    [Button(nameof(TestTween1))]
    [Button(nameof(TestTween2))]
    public float duration;

    public GameObject obj;

    public void TestTween1()
    {
        Sequence sequence = Sequence.Create();

        Tween tween1 = obj.GetComponent<CanvasGroup>().TweenAlpha(0f, duration);
        Tween tween2 = obj.transform.TweenLocalScale(Vector3.zero, duration);

        sequence.Join(tween1);
        sequence.Join(tween2);

        sequence.Play();
    }

    public void TestTween2()
    {
        Sequence sequence = Sequence.Create();

        Tween tween1 = obj.GetComponent<CanvasGroup>().TweenAlpha(1f, duration);
        Tween tween2 = obj.transform.TweenLocalScale(Vector3.one, duration);

        sequence.Join(tween1);
        sequence.Join(tween2);

        sequence.Play();
    }
}
