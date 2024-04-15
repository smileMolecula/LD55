using UnityEngine;
public abstract class Condition : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    [SerializeField] private AudioClip audioClip;
    private ParticleSystem effect;
    public abstract void ActivationCondition();
}