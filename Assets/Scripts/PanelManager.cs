
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject panel;
    [SerializeField] private EquipType requiredEquipType; // Panelin bekledi�i item t�r�
    [SerializeField] private Image panelImage; // De�i�ecek resim
    [SerializeField] private Sprite[] panelStates; // Panelin farkl� a�amalar�ndaki g�rseller
    [SerializeField] private Image[] panelImages; // Panelin farkl� a�amalar�ndaki g�rseller
    private int currentState = 0;
    [SerializeField] private PanelType panelType = PanelType.Normal;
    [SerializeField] private InventoryManager inventoryManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        Equip selectedEquip = InventoryManager.Instance.GetSelectedEquip();

        if (selectedEquip != null && selectedEquip.EquipSO.equipType == requiredEquipType && panelType == PanelType.Normal)
        {
            Debug.Log("Do�ru item kullan�ld�: " + selectedEquip.EquipSO.equipType);

            // Resmi de�i�tir
            if (panelStates.Length > 0 && currentState < panelStates.Length)
            {
                panelImage.sprite = panelStates[currentState++];
            }
            if (currentState >= panelStates.Length)
            {
                //panel.SetActive(false);
                GetComponent<Image>().raycastTarget = false;
                StartCoroutine(ClosePanel());
            }

        }
        
    }

    public void DartPanel(int index)
    {
        Equip selectedEquip = InventoryManager.Instance.GetSelectedEquip();

        if (panelType == PanelType.Extra && selectedEquip != null && selectedEquip.EquipSO.equipType == requiredEquipType)
        {
            panelImages[index].gameObject.SetActive(true);
        }
        if(CheckDarts())
        {
            
            StartCoroutine(ClosePanel());
        }
    }

    public void DolapPanel()
    {
        Equip selectedEquip = InventoryManager.Instance.GetSelectedEquip();

        if (panelType == PanelType.Extra && selectedEquip != null && selectedEquip.EquipSO.equipType == requiredEquipType)
        {
            panelImages[currentState++].gameObject.SetActive(true);
        }
        if (currentState >= panelImages.Length)
        {
            StartCoroutine(ClosePanel());
        }
    }

    public void OpenImage()
    {
        Equip selectedEquip = InventoryManager.Instance.GetSelectedEquip();

        if (panelType == PanelType.Extra && selectedEquip != null && selectedEquip.EquipSO.equipType == requiredEquipType)
        {
            panelImage.gameObject.SetActive(true);
            InventoryManager.Instance.DeleteEquip();
            InventoryManager.Instance.RemoveSelectedEquip();
            panel.SetActive(false);
        }
    }

    public void ChangePanel()
    {
        Equip selectedEquip = InventoryManager.Instance.GetSelectedEquip();

        if (panelType == PanelType.Extra && selectedEquip != null && selectedEquip.EquipSO.equipType == requiredEquipType)
        {
            panelImage.gameObject.SetActive(true);
            InventoryManager.Instance.DeleteEquip();
            InventoryManager.Instance.RemoveSelectedEquip();
            panel.SetActive(false);
        }
    }

    private bool CheckDarts()
    {
        for (int i = 0; i < panelImages.Length; i++)
        {
            if (!panelImages[i].gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ClosePanel()
    {
        InventoryManager.Instance.DeleteEquip();
        InventoryManager.Instance.RemoveSelectedEquip();
        yield return new WaitForSeconds(1f);
        panel.SetActive(false);
    }
}
public enum PanelType { Normal, Extra}

