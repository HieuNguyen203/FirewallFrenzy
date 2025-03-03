using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public static void ShakeScreen()
    {
        ani.SetTrigger("Shake");
    }
}
