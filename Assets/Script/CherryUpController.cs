using UnityEngine;

public class CherryUpController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            CherryUp CherryUp = GetComponent<CherryUp>();

            if (CherryUp != null && playerMove != null)
            {
                CherryUp.ApplyCherryUp(playerMove);
                Destroy(gameObject);
            }
        }
    }
}
