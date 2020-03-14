using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private static AudioSource source;

    
    private void Start() {
        source = GetComponent<AudioSource>();
    }

    
    
    public static void PlaySound(AudioClip clip) {
        source.clip = clip;
        source.Play();
    }
}
