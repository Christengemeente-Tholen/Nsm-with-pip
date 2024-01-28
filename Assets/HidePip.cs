using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePip : MonoBehaviour
{
    public GameObject ndi;
    bool ndiVisible = true;
    public void OnButtonClick()
    {
        ndiVisible = !ndiVisible;
        ndi.SetActive(ndiVisible);
    }
}
