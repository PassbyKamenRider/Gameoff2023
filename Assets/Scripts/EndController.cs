using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EndController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] CinemachineVirtualCamera vm;
    private Animator playerAnimator;

    private void Start() {
        playerAnimator = FindObjectOfType<PlayerController>(true).GetComponent<Animator>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void StartEnding()
    {
        vm.enabled = true;
        videoPlayer.Play();
        playerAnimator.Play("Game_End");
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu2");
    }
}
