using UnityEngine;
public abstract class Condition : MonoBehaviour
{
    protected Animator animator;
    protected ParticleSystem effect;
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip audioClip;
    [SerializeField] protected AnimationClip animClip;
    private void Start()
    {
        animator = GetComponent<Animator>();
        effect = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }
    public abstract void ActivationCondition();
}