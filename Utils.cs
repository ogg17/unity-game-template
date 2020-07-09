using System.Collections;
using UnityEngine;

namespace Main
{
    public static class Utils
    {
        public static IEnumerator MoveToTarget(Transform objTransform, Vector3 target)
        {
            var startPos = objTransform.localPosition;
            float t = 0;

            while (t < 1)
            {
                objTransform.localPosition = Vector3.Lerp(startPos, target, t);
                t += Time.deltaTime / 1.5f;
                yield return null;
            }
        }

        public static IEnumerator MoveToTarget(Transform objTransform, Vector3 target, float speed)
        {
            var startPos = objTransform.localPosition;
            float t = 0;

            while (t < 1)
            {
                objTransform.localPosition = Vector3.Lerp(startPos, target, t);
                t += Time.deltaTime / speed;
                yield return null;
            }
        }
    }
}
