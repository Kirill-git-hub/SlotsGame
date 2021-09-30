using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    protected bool isInstantiatedCopy = false;

    public void DeactivatePopup()
    {
        if (isInstantiatedCopy)
        {
            Destroy(gameObject);
        }
    }
}
