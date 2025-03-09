using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // M�zik dosyalar�n�z� buraya ekleyin
    private AudioSource audioSource;
    private int currentTrackIndex = 0; // �u anda �alan m�zi�in indeksi

    void Start()
    {
        // AudioSource bile�enini al veya ekle
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // �lk m�zi�i �al
        PlayCurrentTrack();
    }

    public void PlayCurrentTrack()
    {
        if (musicClips.Length > 0)
        {
            // �u anki m�zi�i �al
            audioSource.clip = musicClips[currentTrackIndex];
            audioSource.Play();
        }
    }

    public void NextTrack()
    {
        // Bir sonraki m�zi�e ge�
        currentTrackIndex = (currentTrackIndex + 1) % musicClips.Length;
        PlayCurrentTrack();
    }

    public void PreviousTrack()
    {
        // Bir �nceki m�zi�e ge�
        currentTrackIndex = (currentTrackIndex - 1 + musicClips.Length) % musicClips.Length;
        PlayCurrentTrack();
    }
}