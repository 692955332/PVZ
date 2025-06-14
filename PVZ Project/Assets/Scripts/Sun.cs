using UnityEngine;
using DG.Tweening;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1f;
    public int point = 50;

    void Start()
    {
        
    }
    public void JumpTo(Vector3 targetPos)
    {
        targetPos.z = -1;
        Vector3 centerPos = (transform.position + targetPos) / 2f;
        float distance = Vector3.Distance(transform.position,targetPos);

        centerPos.y += (distance / 2);
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom)
            .SetEase(Ease.OutQuad);
    }

    public void OnMouseDown()
    {
        
        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), moveDuration).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
                SunManager.Instance.AddSun(point);
            });

    }
}
