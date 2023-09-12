using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTutorials : MonoBehaviour
{
    public PlayerInput playerInput;  //��ȡ��ǰ��ҿ��Ʒ�ʽ������/�ֱ���

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
        //��ȡ��ǰ�Ĳٿط�ʽ
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
