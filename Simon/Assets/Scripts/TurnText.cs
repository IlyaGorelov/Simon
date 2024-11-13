using TMPro;
using UnityEngine;
using YG;

public class TurnText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    // Update is called once per frame
    void Update()
    {
        if (YandexGame.EnvironmentData.language == "ru")
        {
        if (SimonManager.isBotTurn)
            textMeshPro.text = "Ход Бота";
        else textMeshPro.text = "Ваш ход";
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            if (SimonManager.isBotTurn)
                textMeshPro.text = "Bot's turn";
            else textMeshPro.text = "Your turn";
        }
    }
}
