using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveDistance = 5f; // Kamera kayma mesafesi
    public float moveSpeed = 5f;    // Kamera kayma hýzý
    private Vector3 targetPosition; // Kameranýn hedef pozisyonu

    void Start()
    {
        targetPosition = transform.position; // Baþlangýçta hedef pozisyonu kamera pozisyonuna eþitle
    }

    void Update()
    {
        // Kamera hareketi
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void MoveCameraRight()
    {
        // Kamerayý saða kaydýr
        targetPosition += Vector3.right * moveDistance;
    }

    public void MoveCameraLeft()
    {
        // Kamerayý sola kaydýr
        targetPosition += Vector3.left * moveDistance;
    }
}