using Unity.VisualScripting;
using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 5f;
    private float produceTimer = 0f;
    private Animator anim;
    public GameObject sunPrefab;
    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 2f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceDuration)
        {
            produceTimer = 0f;
            anim.SetTrigger("IsGlowing");
        }
    }
    public void ProduceSun()
    {
        GameObject go = GameObject.Instantiate(sunPrefab, transform.position, Quaternion.identity);
        float distance = Random.Range(jumpMinDistance, jumpMaxDistance);
        distance = Random.Range(0f, 2f) < 1 ? -distance : distance;
        Vector3 position = transform.position;
        position.x += distance;
        go.GetComponent<Sun>().JumpTo(position);
    }
}
