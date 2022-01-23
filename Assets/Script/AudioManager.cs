
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist; //Variable pour stocker les musiques
    public AudioSource audioSource; //Source Audio
    // private int musicIndex = 0; // Liste des musique par numeros 

        
    void Start()
    {
        //Charge la 1er musique
        audioSource.clip = playlist[0];
        //Joue la musique
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Si la chanson est fini de jouer passer a la suivante
        if(!audioSource.isPlaying)
        {
            // PlayNextSong();
        }
    }

    // Pour jouer les musiques a la suite
    void PlayNextSong()
    {
        // musicIndex = (musicIndex + 1) % playlist.Length;
        // audioSource.clip = playlist[musicIndex];
        // audioSource.Play();
    }
}
