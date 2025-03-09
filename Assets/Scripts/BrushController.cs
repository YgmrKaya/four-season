using UnityEngine;

public class BrushController : MonoBehaviour
{
    void Update()
    {
        // Mouse pozisyonunu al ve d�nya koordinatlar�na �evir
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D oyun i�in z eksenini s�f�rla

        // F�r�ay� mouse pozisyonuna ta��
        transform.position = mousePosition;
    }

}
