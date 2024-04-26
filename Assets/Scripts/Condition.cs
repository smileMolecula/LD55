using UnityEngine;
public abstract class Condition : MonoBehaviour
{
    protected Animator animator;
    protected GameObject effectPrefab;
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip audioClip;
    [SerializeField] protected AnimationClip animClip;
    protected void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void ActivationCondition()
    {
        if(animator)
        {
            animator.Play(animClip.name);
        }
        if(audioSource)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        if(effectPrefab)
        {
            GameObject effectObject = Instantiate(effectPrefab,transform.position,Quaternion.identity);
            ParticleSystem effect = effectObject.GetComponent<ParticleSystem>();
            effect.Play();
            Destroy(gameObject,effect.main.duration);
        }
        ConditionMethod();
    }
    protected abstract void ConditionMethod();
}