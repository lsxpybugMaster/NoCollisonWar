using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTutorials : MonoBehaviour
{
    public PlayerInput playerInput;  //获取当前玩家控制方式（键盘/手柄）

    public GameObject[] tutorialInfo;

   
    private void Update()
    {
        Debug.Log("from Player :: " + playerInput.currentControlScheme);
    }

    public void ShowKeyBoardTutorialInfo()
    {
        tutorialInfo[0].SetActive(true);
        tutorialInfo[1].SetActive(false);
    }

    public void ShowGamePadTutorialInfo()
    {
        tutorialInfo[0].SetActive(false);
        tutorialInfo[1].SetActive(true);
    }

    public void control_changed_event()
    {
        //获取当前的操控方式
        if (playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            ShowKeyBoardTutorialInfo();
        }
        else if (playerInput.currentControlScheme == "GamePad")
        {
            ShowGamePadTutorialInfo();
        }
        Debug.Log("control_changed_event");
    }
}
