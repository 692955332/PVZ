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
    //冷却 可以被点击 不可用
    private CardState cardState = CardState.Cooling;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    public float cdTime = 2f; //冷却时间
    public float cdTimer = 0f; //冷却时间最大值

    private void Update()
    {
        switch(cardState)
        {
            case CardState.Cooling:
                //冷却中
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                //等待阳光
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                //准备好
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
        throw new NotImplementedException();
    }
    private void ReadyUpdate()
    {
        throw new NotImplementedException();
    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    } 


}
