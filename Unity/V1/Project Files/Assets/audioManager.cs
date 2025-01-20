using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] AudioSource soundEffects;

    public AudioClip bounce;

    public void bounce_sound() {
        soundEffects.PlayOneShot(bounce);
    }
}