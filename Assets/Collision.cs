using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "End")
        {
            // Application.Quit();
            Application.LoadLevel(Application.loadedLevel);
            Application.OpenURL("https://www.youtube.com/watch?v=HIPQQ4qnl6Q");

        }
    }
}
