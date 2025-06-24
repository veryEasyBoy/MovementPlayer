using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    public Action SpeedChange;

    [SerializeField] protected Character character;
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
    [SerializeField] protected float height;
    protected Fsm fsm;
    protected MouseSens mouseSens;
    public Transform PlayerPosition => playerPosition;
    public CapsuleCollider CapsuleCollider => capsuleCollider;
    public float Speed { get { return character.speed; } set { { character.speed = value; } } }
}
