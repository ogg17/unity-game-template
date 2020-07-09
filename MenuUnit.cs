using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class MenuUnit : BaseUnit
    {
        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 endPos;
        [SerializeField] private float speed;

        private Vector3 pos;
        private bool isEndPos;

        public override void OnStart()
        {
            pos = startPos;
        }

        public override void OnUpdate()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, speed * Time.deltaTime);
        }
        public void ToNextPos()
        {
            if (isEndPos)
            {
                isEndPos = false;
                pos = startPos;
            }
            else
            {
                isEndPos = true;
                pos = endPos;
            }
        }
    }
}
