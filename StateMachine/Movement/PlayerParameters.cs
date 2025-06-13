using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    [SerializeField] protected CharacterStats characterStats;
    [SerializeField] protected PlayerSlideStats slideStats;
    [SerializeField] protected MousStats mousStats;
    [SerializeField] protected Transform playerPosition;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected Transform transformAimTarget;
    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip[] audioClip;
    protected Fsm fsm;
    protected MouseSens mouseSens;
    public Transform PlayerPosition => playerPosition;
    public CapsuleCollider CapsuleCollider => capsuleCollider;
}
