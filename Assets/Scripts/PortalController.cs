using UnityEngine;

public class PortalController : MonoBehaviour
{

    private UIManager _uiManager;
    private ScoreManager _scoreManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_scoreManager.GetNestsLeft() <= 0)
            {
                _uiManager.LoadWinScene();
            }
            else
            {
                _uiManager.LoadFailScene();
            }
        }
    }
}
