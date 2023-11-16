using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private GameObject swordFrame;
    [SerializeField] private GameObject characterFrame;

    public void MoveToCharacter()
    {
        characterFrame.SetActive(true);
        canvasAnimator.Play("Focus_Book");
    }

    public void MoveToSword()
    {
        swordFrame.SetActive(true);
        canvasAnimator.Play("Focus_Sword");
    }
}
