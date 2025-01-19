using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource soundEffects;

    public AudioClip jump;
    public AudioClip die;
    public AudioClip hit;
    public AudioClip point;

    public void soundEffect(AudioClip clip) {
        soundEffects.PlayOneShot(clip);
    }
}
