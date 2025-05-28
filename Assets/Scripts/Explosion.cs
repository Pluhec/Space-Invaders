using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    public AudioClip clip;
    
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator.runtimeAnimatorController == null)
        {
            Debug.LogWarning("Explosion: chybí Animator Controller!", this);
            Destroy(gameObject, 1f);
            return;
        }
        AudioManager.Instance.PlaySFX(clip);
        
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