using System.Collections;
using UnityEngine;

public class audioPlayerHome : MonoBehaviour
{   
    public static audioPlayerHome instance;

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

    public AudioSource audio_draw_home, audio_eraser_home;

    public void play_audio_draw_home()
    {
        audio_draw_home.Play();
    }

    public void stop_audio_draw_home()
    {
        audio_draw_home.Stop();
    }

    public void play_audio_eraser_home()
    {
        audio_eraser_home.Play();
    }




}
