using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial1;
    public GameObject tutorial2;

    private int i = 0;

    public void Advance(CallbackContext ctx)
    {
        if (!ctx.started)
        {
            return;
        }

        if (i == 0)
        {
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
        }
        if (i == 1)
        {
            SceneManager.LoadScene("Game");
        }

        i++;
    }
}
