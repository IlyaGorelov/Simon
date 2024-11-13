using TMPro;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public static bool isLose = false;
    public static int score;
    public static int maxScore;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI maxScoreText;
    [SerializeField] SimonManager simonManager;
    [SerializeField] SimonPlayerOrder simonPlayerOrder;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject bStart;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled) Load();
    }

    private void Load()
    {
        maxScore = YandexGame.savesData.maxScore;
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        maxScoreText.text = maxScore.ToString();
        if (isLose)
            Lose.SetActive(true);
        else 
            Lose.SetActive(false);
    }

    public void MuteSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void Restart()
    {
        score = 0;
        YandexGame.FullscreenShow();
        Save();
        SimonManager.canStart = false;
        simonManager.order.Clear();
        simonManager.order.Add(Random.Range(1, 5));
        simonPlayerOrder.playerOrder.Clear();
        bStart.SetActive(true);
        isLose = false;
    }

    private void Save()
    {
        YandexGame.savesData.maxScore = maxScore;
        YandexGame.SaveProgress();
    }
}
