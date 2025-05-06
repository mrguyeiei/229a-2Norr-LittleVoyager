using UnityEngine;
using UnityEngine.SceneManagement;

public class YourWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove component = other.gameObject.GetComponent<PlayerMove>();
        if (component != null)
        {
            SceneManager.LoadScene("YourWin");
        }
    }
}