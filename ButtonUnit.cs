using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Main
{
    [RequireComponent(typeof(Image))]
    public abstract class ButtonUnit : BaseUnit, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Color buttonColor;
        public Color clickColor;
        
        private Image buttonImage;
        private bool isDown = false;
        private readonly float offsetColor = 0.001f;
        private readonly float time = 0.03f;

        public override void OnStart()
        {
            buttonImage = GetComponent<Image>();
            var color = buttonImage.color;
            buttonColor = color;
            clickColor = color - new Color32(32,32,32,0);
        }

        public override void OnUpdate()
        {
            if(!isDown && buttonImage.color.r < buttonColor.r - offsetColor) 
                buttonImage.color = Color.Lerp(buttonImage.color, buttonColor, time);
        }

        public void OnPointerClick(PointerEventData eventData) => OnClick();
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown();
            buttonImage.color = clickColor;
            isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp();
            isDown = false;
        }

        protected virtual void OnClick(){}
        protected virtual void OnDown(){}
        protected virtual void OnUp(){}
    
    }
}
