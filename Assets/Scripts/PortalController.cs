using UnityEngine;

public class PortalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<UIManager>().LoadWinScene();
        }
    }
}
