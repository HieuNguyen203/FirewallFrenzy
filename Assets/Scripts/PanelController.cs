using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
