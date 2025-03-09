using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // Müzik dosyalarýnýzý buraya ekleyin
    private AudioSource audioSource;
    private int currentTrackIndex = 0; // Þu anda çalan müziðin indeksi

    void Start()
    {
        // AudioSource bileþenini al veya ekle
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ýlk müziði çal
        PlayCurrentTrack();
    }

    public void PlayCurrentTrack()
    {
        if (musicClips.Length > 0)
        {
            // Þu anki müziði çal
            audioSource.clip = musicClips[currentTrackIndex];
            audioSource.Play();
        }
    }

    public void NextTrack()
    {
        // Bir sonraki müziðe geç
        currentTrackIndex = (currentTrackIndex + 1) % musicClips.Length;
        PlayCurrentTrack();
    }

    public void PreviousTrack()
    {
        // Bir önceki müziðe geç
        currentTrackIndex = (currentTrackIndex - 1 + musicClips.Length) % musicClips.Length;
        PlayCurrentTrack();
    }
}