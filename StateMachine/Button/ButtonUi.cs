using Cysharp.Threading.Tasks.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUi : MonoBehaviour
{
    public void Button(ButtonPanel[] buttonControllerPanel, int num, Action activeButton) 
    {
        if (buttonControllerPanel[num].Pressed)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == buttonControllerPanel[num].fingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                         activeButton();
                    }
                }

            }

        }
    }
}
