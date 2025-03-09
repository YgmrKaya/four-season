using UnityEngine;

public class PreviousButton : MonoBehaviour
{
    public MusicManager musicManager; // MusicManager scriptine referans

    void OnMouseDown()
    {
        if (musicManager != null)
        {
            musicManager.PreviousTrack(); // Bir önceki müziði çal
        }
    }
}