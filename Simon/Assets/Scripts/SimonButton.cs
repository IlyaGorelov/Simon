using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimonButton : MonoBehaviour
{
    [SerializeField] SimonPlayerOrder m_PlayerOrder;
    [SerializeField] SimonManager simonManager;
    [SerializeField] int buttonId = 1;
    [SerializeField] GameObject shineImage;

    private Image image;
    private void Start()
    {
        m_PlayerOrder = GetComponentInParent<SimonPlayerOrder>();
    }

    public void ShineFromButton()
    {
        StartCoroutine(Do1(false));
        m_PlayerOrder.playerOrder.Add(buttonId);
        int i = m_PlayerOrder.playerOrder.IndexOf(buttonId);
        if (simonManager.order[i] != m_PlayerOrder.playerOrder[i])
            GameManager.isLose = true;
    }

    public void ShineFromScript()
    {
        StartCoroutine(Do1(true));
       
    }

    

    IEnumerator Do1(bool isFromScript)
    {
        if (!isFromScript)
        {
            gameObject.transform.localScale = new Vector2(0.95f, 0.95f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector2(1f, 1f);

            shineImage.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            shineImage.SetActive(false);
        }
        else
        {
            shineImage.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            shineImage.SetActive(false);
        }
    }
}
