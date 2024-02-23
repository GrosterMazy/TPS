using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public List<Transform> targets;
    public Transform player; 
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    public bool _eyeContactWithPlayer;

    void PickNewTarget() {
        this._navMeshAgent.destination = this.targets[Random.Range(0, this.targets.Count)].position;
    }

    void Start() {
        this._navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.PickNewTarget();
    }

    void Update() {
        Vector3 direction = this.player.position - this.transform.position;
        RaycastHit hit;
        this._eyeContactWithPlayer = false;
        if (Vector3.Angle(this.transform.forward, direction) < this.viewAngle
                && Physics.Raycast(this.transform.position + Vector3.up, direction, out hit)
                && hit.collider.gameObject == player.gameObject)
            this._eyeContactWithPlayer = true;

        if (this._eyeContactWithPlayer)
            this._navMeshAgent.destination = this.player.position;
        else if (this._navMeshAgent.remainingDistance == 0)
            this.PickNewTarget();
    }
}
