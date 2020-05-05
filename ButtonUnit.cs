using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ButtonUnit : BaseUnit, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Color32 ButtonColor { get; set; }
    public Color32 ClickColor { get; set; }
    
    private Image buttonImage;
    private bool isDown = false;
    private float offsetColor = 0.05f;
    private float time = 0.03f;
    
    public override void OnStart()
    {
        buttonImage = GetComponent<Image>();
        ButtonColor = new Color32(249, 249, 249, 255);
        ClickColor = new Color32(192, 192, 192, 255);
    }

    public override void OnUpdate()
    {
        if(!isDown && buttonImage.color.r < ButtonColor.r - offsetColor) 
            buttonImage.color = Color.Lerp(buttonImage.color, ButtonColor, time);
    }

    public void OnPointerClick(PointerEventData eventData) => OnClick();
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown();
        buttonImage.color = ClickColor;
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