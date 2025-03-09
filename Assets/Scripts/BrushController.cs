using UnityEngine;

public class BrushController : MonoBehaviour
{
    void Update()
    {
        // Mouse pozisyonunu al ve dünya koordinatlarýna çevir
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D oyun için z eksenini sýfýrla

        // Fýrçayý mouse pozisyonuna taþý
        transform.position = mousePosition;
    }

}
