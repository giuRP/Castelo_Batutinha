using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteraction : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.white;

    private List<Material> materials;

    private void Awake()
    {
        materials = new List<Material>();

        foreach (var renderer in renderers)
        {
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach(var material in materials)
            {
                if (material.HasProperty("_isHighlighted"))
                {
                    material.SetInt("_isHighlighted", 1);

                    if (material.HasProperty("_Color"))
                    {
                        material.SetColor("_Color", color);
                    }
                }
                else
                    continue;
            }
        }
        else
        {
            foreach(var material in materials)
            {
                if (material.HasProperty("_isHighlighted"))
                {
                    material.SetInt("_isHighlighted", 0);
                }
                else
                    continue;
            }
        }
    }
}
