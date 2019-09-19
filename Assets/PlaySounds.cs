using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour
{
    AudioSource aud;

    public AudioClip sound;
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) {
            aud.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
            Destroy(this.gameObject, 1);
            Destroy(this.GetComponent<Renderer>());
            Destroy(this);
        }
    }
}
