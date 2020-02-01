using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WinCounter : MonoBehaviour
{
    public int WinLimit;
    public int Cars;
    public IconBar Slider;

    public UnityEvent OnWin;

    public void CarReachGoal() {
        Cars++;

        Slider.Value = Cars;

        if (Cars >= WinLimit)
            OnWin.Invoke();

        
    }
}
