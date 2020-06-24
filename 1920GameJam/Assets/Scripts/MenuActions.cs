using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam1920.Assets.Scripts
{
    public class MenuActions : MonoBehaviour
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}