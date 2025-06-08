using UnityEngine;
using DG.Tweening;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1f;
    public void JumpTo(Vector3 targetPos)
    {
        Vector3 centerPos = (transform.position + targetPos) / 2f;
        float distance = Vector3.Distance(transform.position,targetPos);

        centerPos.y = (distance / 2);
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom)
            .SetEase(Ease.OutQuad);
    }
}
