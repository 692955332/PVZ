using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


enum CardState
{
    Cooling,
    WaitingSun,
    Ready,
}
public class Card : MonoBehaviour
{
    private CardState cardState = CardState.Cooling;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    [SerializeField]
    private float cdTime = 2f;
    private float cdTimer = 0f; 
    [SerializeField]
    public int needSunPoint = 50; 

    private void Update()
    {
        switch(cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    private void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }

    }
    private void WaitingSunUpdate()
    {
        if (needSunPoint <= SunManager.Instance.SunPoint)
        {
            TransitionToReady();
        }
    }
    private void ReadyUpdate()
    {
        if (needSunPoint > SunManager.Instance.SunPoint)
        {
            TransitionToWaitingSun();
        }

    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    } 
    void TransitionToReady()
    {
        cardState = CardState.Ready;
        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }
    public void TransitionToCooling()
    {
        cardState = CardState.Cooling;
        cdTimer = 0f;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);

    }

    public void OnClick()
    {
        if(needSunPoint > SunManager.Instance.SunPoint) return;
        //TODO：进行种植
        SunManager.Instance.SubSun(needSunPoint);
        TransitionToCooling();
    }

}
