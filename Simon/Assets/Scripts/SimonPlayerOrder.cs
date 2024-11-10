using System.Collections.Generic;
using UnityEngine;

public class SimonPlayerOrder : MonoBehaviour
{
    public List<int> playerOrder;
    [SerializeField] SimonManager simonManager;

    private void Start()
    {
        playerOrder = new();
    }

    private void Update()
    {
        if(playerOrder.Count==simonManager.order.Count && !GameManager.isLose)
        {
            GameManager.score += 1;
            simonManager.order.Add(Random.Range(1, 5));
            SimonManager.canStart = true;
            playerOrder.Clear();
        }
        if (GameManager.maxScore < GameManager.score)
            GameManager.maxScore = GameManager.score;
    }
}
