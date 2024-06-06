using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class animated_UI_image_script : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Image uiImage;
    public Sprite[] animatedSprites;
    public Sprite staticSprite;
    public int framesPerSprite = 5;

    private int currentFrame = 0;
    private int frameCounter = 0;
    private bool isMouseOver = false;

    void FixedUpdate()
    {
        if (isMouseOver)
        {
            frameCounter++;
            if (frameCounter >= framesPerSprite)
            {
                frameCounter = 0;
                currentFrame = (currentFrame + 1) % animatedSprites.Length;
                uiImage.sprite = animatedSprites[currentFrame];
            }
        }
        else
        {
            uiImage.sprite = staticSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        currentFrame = 0;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        uiImage.sprite = staticSprite;
    }



}
