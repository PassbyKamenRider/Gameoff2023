using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimationController : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator swordAnimator;
    [SerializeField] private GameObject swordFrame;
    [SerializeField] private GameObject characterFrame;
    [SerializeField] private DrawManager drawManager;

    public void MoveToCharacter()
    {
        playerAnimator.Play("Menu_To_Edit");
        canvasAnimator.Play("Focus_Book");
        swordAnimator.Play("Sword_To_Char");
        Invoke("ToggleCharacterDraw", 1f);
    }

    public void MoveToSword()
    {
        swordAnimator.Play("Menu_To_Edit_Sword");
        canvasAnimator.Play("Focus_Sword");
        Invoke("ToggleSwordDraw", 1f);
    }

    public void SwordToMenu()
    {
        drawManager.ToLocalSpace();
        swordAnimator.Play("Edit_To_Menu_Sword");
        canvasAnimator.Play("Sword_To_Menu");
        ToggleSwordDraw();
    }

    public void CharacterToMenu()
    {
        drawManager.ToLocalSpace();
        playerAnimator.Play("Edit_To_Menu");
        canvasAnimator.Play("Character_To_Menu");
        swordAnimator.Play("Char_To_Sword");
        ToggleCharacterDraw();
    }

    public void ToggleSwordDraw()
    {
        swordFrame.SetActive(!swordFrame.activeSelf);
    }
    
    public void ToggleCharacterDraw()
    {
        characterFrame.SetActive(!characterFrame.activeSelf);
    }

    public void StartGame()
    {
        swordAnimator.Play("Sword_To_Char");
        playerAnimator.Play("Menu_To_Open");
        canvasAnimator.Play("Book_Open");
    }
}
