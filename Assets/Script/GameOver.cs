using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove component = other.gameObject.GetComponent<PlayerMove>();
        if (component != null)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
