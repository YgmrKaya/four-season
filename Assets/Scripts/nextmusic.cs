using UnityEngine;

public class NextButton : MonoBehaviour
{
    public MusicManager musicManager; // MusicManager scriptine referans

    void OnMouseDown()
    {
        if (musicManager != null)
        {
            musicManager.NextTrack(); // Bir sonraki m�zi�i �al
        }
    }
}