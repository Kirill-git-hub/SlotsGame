using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup
{
    protected bool isActivePopup = true;

    protected void DisactivatePopup(GameObject obj)
    {
        if (isActivePopup)
        {
            obj.SetActive(!isActivePopup);
        }
    }
}
