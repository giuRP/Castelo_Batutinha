using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class change_image_ui_script : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    
    private Image imageComponent;
    

    public UnityEvent on_hover;
    public UnityEvent off_hover;

    void Start()
    {
        imageComponent = GetComponent<Image>();
       

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetAlphaToZero();
        on_hover.Invoke();


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetAlphaToOneHundred();
        off_hover.Invoke();
       
    }

    public void SetAlphaToZero()
    {
        Color currentColor = imageComponent.color;
        currentColor.a = 0f;
        imageComponent.color = currentColor;
    }

    public void SetAlphaToOneHundred()
    {
        Color currentColor = imageComponent.color;
        currentColor.a = 1f;
        imageComponent.color = currentColor;
    }

    


}
