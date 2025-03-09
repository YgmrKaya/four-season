using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    private Transform parentAfterDrag; // S�n�f d�zeyinde tan�mland�

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent; // Mevcut parent'� sakla
        transform.SetParent(transform.root); // Canvas'a ta��
        transform.SetAsLastSibling(); // En �stte g�ster
        image.raycastTarget = false; // Raycast'i devre d��� b�rak
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Fare pozisyonunu takip et
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag); // Eski parent'a geri d�n
        image.raycastTarget = true; // Raycast'i tekrar etkinle�tir
    }
}
