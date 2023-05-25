using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public KeyCode BackToMenu = KeyCode.Escape;
    private void Update()
    {
        if(Input.GetKeyDown(BackToMenu))
        {
            SceneManager.LoadScene(0);
        }
    }
}
