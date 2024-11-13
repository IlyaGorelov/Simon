using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonManager : MonoBehaviour
{
    public List<int> order;
    [SerializeField] SimonButton[] simonButtons;
    public static bool canStart = false;
    public static bool isBotTurn = true;

    private void Start()
    {
        order = new();
        order.Add(Random.Range(1, 5));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            simonButtons[0].ShineFromButton();
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            simonButtons[1].ShineFromButton();
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            simonButtons[2].ShineFromButton();
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            simonButtons[3].ShineFromButton();

        if (canStart)
        {
            canStart = false;
            isBotTurn = true;
            StartCoroutine(HighLightButtons());
        }
    }

    IEnumerator HighLightButtons()
    {
            yield return new WaitForSeconds(1f);
        for (int i = 0; i < order.Count; i++)
        {
            switch (order[i])
            {
                case 1:
                    simonButtons[0].ShineFromScript();
                    break;
                case 2:
                    simonButtons[1].ShineFromScript();
                    break;
                case 3:
                    simonButtons[2].ShineFromScript();
                    break;
                case 4:
                    simonButtons[3].ShineFromScript();
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        isBotTurn = false;
    }
}
