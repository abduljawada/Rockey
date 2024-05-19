using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float offsetY;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text gameOverButtonText;
    [SerializeField] private GameObject factory1;
    [SerializeField] private GameObject factory2;
    [SerializeField] private GameObject factory3;
    private int _score;
    private bool _isGameOverTriggered;

    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        timerText.text = "Time: " + (int) Time.time;

        if (!factory1 && !factory2 && !factory3)
        {
            GameOver();
        }
    }

    public void Spawn()
    {
        if (Camera.main == null) return;
        var maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Instantiate(meteorPrefab, new Vector3(Random.Range(- maxPos.x, maxPos.x), maxPos.y + offsetY, 0f), Quaternion.Euler(0, 0, Random.Range(-45f, 135f)));
    }

    public void ModifyScore(int scoreIncrease = 1)
    {
        _score += scoreIncrease;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        if (_isGameOverTriggered) return;
        
        _isGameOverTriggered = true;
        gameOverScreen.SetActive(true);
        StartCoroutine(AnimateTextFadeIn(gameOverText));
        StartCoroutine(AnimateTextFadeIn(gameOverButtonText));
    }

    private static IEnumerator AnimateTextFadeIn(Graphic target)
    {
        target.color = new Color(target.color.r, target.color.g, target.color.b, 0.001f);
        while (target.color.a < 1f)
        {
            target.color = new Color(target.color.r, target.color.g, target.color.b, target.color.a * 2);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
