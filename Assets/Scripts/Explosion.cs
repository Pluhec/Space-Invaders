using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator.runtimeAnimatorController == null)
        {
            Debug.LogWarning("Explosion: chybí Animator Controller!", this);
            Destroy(gameObject, 1f);
            return;
        }
        
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        float clipLength = 0f;
        foreach (var clip in clips)
        {
            if (clip.name.ToLower().Contains("explosion"))
            {
                clipLength = clip.length;
                break;
            }
        }
        if (clipLength <= 0f && clips.Length > 0)
            clipLength = clips[0].length;
        
        Destroy(gameObject, clipLength);
    }
}