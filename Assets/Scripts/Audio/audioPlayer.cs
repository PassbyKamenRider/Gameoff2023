using System.Collections;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{   
    public static audioPlayer instance;
    private bool isWalking =false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audio_pick, audio_sword, audio_spin, audio_eraser, audio_dog, audio_draw, audio_zoom, audio_walk, audio_jump;


    public void play_audio_jump()
    {
        audio_jump.Play();
    }

    public void play_audio_pick()
    {
        audio_pick.Play();
    }

    public void play_audio_sword()
    {
        audio_sword.Play();
    }

    public void play_audio_spin()
    {
        audio_spin.Play();
    }


    public void play_audio_eraser()
    {
        audio_eraser.Play();
    }

    public void play_audio_dog()
    {
        audio_dog.Play();
    }

    public void play_audio_draw()
    {
        audio_draw.Play();
    }

    public void play_audio_zoom()
    {
        audio_zoom.time = 0.2f;
        audio_zoom.Play();
    }

    public void play_audio_walk()
    {
        audio_walk.Play();
        isWalking = true;
    }

    public void stop_audio_walk()
    {
        isWalking = false;
        if (audio_walk.isPlaying)
        {
            float halfDuration = audio_walk.clip.length / 2;

            if (audio_walk.time <= halfDuration)
            {
                // If currently in the first half
                StartCoroutine(StopAfterDelay(audio_walk, halfDuration - audio_walk.time));
            }
            else
            {
                // If currently in the second half
                float remainingTimeInClip = audio_walk.clip.length - audio_walk.time;
                StartCoroutine(StopAfterDelay(audio_walk, remainingTimeInClip));
            }
        }
    }

    IEnumerator StopAfterDelay(AudioSource audioSource, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isWalking) {
            audioSource.Stop();
        }
    }


    public void stop_audio_draw()
    {
        audio_draw.Stop();
    }

    public void stop_audio_eraser()
    {
        audio_eraser.Stop();
    }


}
