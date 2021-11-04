using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupController 
{
    private PausePopup pausePopup;
    
    public PausePopup PausePopup { get => pausePopup; set => pausePopup = value; }

    public PopupController()
    {
        pausePopup = new PausePopup();
    }
}
