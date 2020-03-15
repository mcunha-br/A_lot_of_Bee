using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private Text _scoreText;
    
    private int _nestsLeft = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetNestsLeft() <= 0)
        {
            _scoreText.fontSize= 52;
            _scoreText.text = "Reach the end to find the PINK PORTAL!";
        }
        else
        {
            _scoreText.text = GetNestsLeft().ToString();
        }
    }

    public void IncreaseDestroyedNests()
    {
        _nestsLeft--;
    }

    public int GetNestsLeft()
    {
        return _nestsLeft;
    }
    
    private void OnDestroy()
    {
        _nestsLeft = 7;
    }
}
