using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene("Start");
    }

    public void Endless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level(string name)
    {
        SceneManager.LoadScene(name);
    }
}
