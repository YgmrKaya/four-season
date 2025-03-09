using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    private Transform parentAfterDrag; // Sýnýf düzeyinde tanýmlandý

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent; // Mevcut parent'ý sakla
        transform.SetParent(transform.root); // Canvas'a taþý
        transform.SetAsLastSibling(); // En üstte göster
        image.raycastTarget = false; // Raycast'i devre dýþý býrak
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Fare pozisyonunu takip et
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag); // Eski parent'a geri dön
        image.raycastTarget = true; // Raycast'i tekrar etkinleþtir
    }
}
