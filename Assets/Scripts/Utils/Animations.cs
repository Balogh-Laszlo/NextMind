using System.Collections;
using TMPro;
using UnityEngine;

namespace Utils
{
    public static class Animations
    {
        //from https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/
        public static IEnumerator FadeTextToZeroAlpha(float t, TMP_Text i)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }
        }
    }
}