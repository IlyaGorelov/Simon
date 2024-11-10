using UnityEngine;
using YG;

public class ActivateDifCanvas : MonoBehaviour
{
    [SerializeField] GameObject PCCanvas;
    [SerializeField] GameObject MobileCanvas;

    private void Start()
    {
        if(YandexGame.EnvironmentData.deviceType == "desktop")
            PCCanvas.SetActive(true);
        else
            MobileCanvas.SetActive(true);
    }
}
