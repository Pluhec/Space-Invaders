using UnityEngine;

public class ParallaxPlayer : MonoBehaviour
{
    public Transform player;

    public float offsetMultiplier = 1f;
    public float smoothTime = 0.3f;

    private Vector3 startBackgroundPos;
    private Vector3 startPlayerPos;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("ParallaxFollowPlayer: chybí reference na hráče!", this);
            enabled = false;
            return;
        }
        
        startBackgroundPos = transform.position;
        startPlayerPos = player.position;
    }

    private void LateUpdate()
    {
        Vector3 playerDelta = player.position - startPlayerPos;
        Vector3 targetPos = startBackgroundPos + playerDelta * offsetMultiplier;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}