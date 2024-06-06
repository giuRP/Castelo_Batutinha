using UnityEngine;
using UnityEngine.EventSystems;

public class highlight_other_objects_script : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject[] objectsToHighlight;
    
    public Animator[] animatorsToActivate;

    public void OnSelect(BaseEventData eventData)
    {
        // Button is selected, highlight the specified objects.
        Highlight(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Button is deselected, remove the highlight from the specified objects.
        Highlight(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // When the mouse enters the button, highlight the specified objects.
        Highlight(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When the mouse exits the button, remove the highlight from the specified objects.
        Highlight(false);
    }

    private void Highlight(bool highlight)
    {
        foreach (var obj in objectsToHighlight)
        {
            obj.SetActive(highlight);
        }
        foreach (var animator in animatorsToActivate)
        {
            animator.enabled = highlight;
        }
    }


    
}
