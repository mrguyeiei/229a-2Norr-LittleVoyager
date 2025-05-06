using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ReturntoMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void Next()
    {
        SceneManager.LoadScene("End");
    }
}
