using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SimonButton : MonoBehaviour
{
    [SerializeField] SimonPlayerOrder m_PlayerOrder;
    [SerializeField] SimonManager simonManager;
    [SerializeField] int buttonId = 1;
    [SerializeField] GameObject shineImage;
    private AudioSource audio;

    private Image image;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        m_PlayerOrder = GetComponentInParent<SimonPlayerOrder>();
    }

    public void ShineFromButton()
    {
        if (!SimonManager.isBotTurn)
        {


            StartCoroutine(Do1(false));
            m_PlayerOrder.playerOrder.Add(buttonId);
            int i = m_PlayerOrder.playerOrder.LastIndexOf(buttonId);
            if (simonManager.order[i] != m_PlayerOrder.playerOrder[i])
            {
                YandexGame.GameplayStop();
                GameManager.isLose = true;
            }
        }
    }

    public void ShineFromScript()
    {
        StartCoroutine(Do1(true));

    }

    public void MinSize() => gameObject.transform.localScale = new Vector2(0.85f, 0.85f);

    public void MaxSize() => gameObject.transform.localScale = new Vector2(1f, 1f);

    IEnumerator Do1(bool isFromScript)
    {
        if (!isFromScript)
        {
            audio.Play();
            shineImage.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            shineImage.SetActive(false);
        }
        else
        {
            audio.Play();
            shineImage.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            shineImage.SetActive(false);
        }
    }
}
