using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveDistance = 5f; // Kamera kayma mesafesi
    public float moveSpeed = 5f;    // Kamera kayma h�z�
    private Vector3 targetPosition; // Kameran�n hedef pozisyonu

    void Start()
    {
        targetPosition = transform.position; // Ba�lang��ta hedef pozisyonu kamera pozisyonuna e�itle
    }

    void Update()
    {
        // Kamera hareketi
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void MoveCameraRight()
    {
        // Kameray� sa�a kayd�r
        targetPosition += Vector3.right * moveDistance;
    }

    public void MoveCameraLeft()
    {
        // Kameray� sola kayd�r
        targetPosition += Vector3.left * moveDistance;
    }
}