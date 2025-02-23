using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HighlightOnHover : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Renderer objectRenderer;

    private List<Material> baseMaterials = new List<Material>();

    private void Awake()
    {
        if (!objectRenderer)
        {
            Debug.LogError("No renderer assigned");
            gameObject.SetActive(false);
        }

        baseMaterials = objectRenderer.materials.ToList();
    }

    private void OnMouseEnter()
    {
        var materials = objectRenderer.materials.ToList();
        materials.Add(highlightMaterial);
        objectRenderer.SetMaterials(materials);
    }

    private void OnMouseExit()
    {
        objectRenderer.SetMaterials(baseMaterials);
    }
}
