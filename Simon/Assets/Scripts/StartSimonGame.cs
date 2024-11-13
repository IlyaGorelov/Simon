using UnityEngine;
using YG;

public class StartSimonGame : MonoBehaviour
{
    public void StartGame()
    {
        YandexGame.GameplayStart();
        SimonManager.canStart = true;
        gameObject.SetActive(false);
    }
}
