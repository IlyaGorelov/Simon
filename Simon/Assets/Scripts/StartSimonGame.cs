using UnityEngine;

public class StartSimonGame : MonoBehaviour
{
    public void StartGame()
    {
        SimonManager.canStart = true;
        gameObject.SetActive(false);
    }
}
