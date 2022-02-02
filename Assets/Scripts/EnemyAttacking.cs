using System;
using Pathfinding;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour {
    private AIPath path;
    [SerializeField] private Animator swordAnim;
    private static readonly int Attacking = Animator.StringToHash("Attacking");

    void Start() {
        path = GetComponent<AIPath>();
    }

    private void Update() {
        if (path.reachedEndOfPath) {
            swordAnim.SetBool(Attacking, true);
        }
    }
}