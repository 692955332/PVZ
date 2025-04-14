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
    //��ȴ ���Ա���� ������
    private CardState cardState = CardState.Cooling;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    public float cdTime = 2f; //��ȴʱ��
    public float cdTimer = 0f; //��ȴʱ�����ֵ

    private void Update()
    {
        switch(cardState)
        {
            case CardState.Cooling:
                //��ȴ��
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                //�ȴ�����
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                //׼����
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
