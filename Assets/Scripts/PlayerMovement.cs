using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float gravity;
    public float jumpVelocity;
    public float moveSpeed;
    public Transform fantomPlayer;
    public Transform playerModel;

    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector = Vector3.zero;
    private bool _w, _a, _s, _d;

    void Start() {
        _characterController = this.GetComponent<CharacterController>();
    }
    
    void Update() {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded) this._fallVelocity = -this.jumpVelocity;

        this._w = false;
        this._a = false;
        this._s = false;
        this._d = false;
        if (Input.GetKey(KeyCode.W)) this._w = true;
        if (Input.GetKey(KeyCode.A)) this._a = true;
        if (Input.GetKey(KeyCode.S)) this._s = true;
        if (Input.GetKey(KeyCode.D)) this._d = true;

        if (this._w || this._a || this._s || this._d)
            this.playerModel.localEulerAngles = new Vector3(
                this.playerModel.localEulerAngles.x,
                this.fantomPlayer.localEulerAngles.y,
                this.playerModel.localEulerAngles.z
            );
        
        this._moveVector = Vector3.zero;
        if (this._w) this._moveVector += this.playerModel.forward;
        if (this._a) this._moveVector -= this.playerModel.right;
        if (this._s) this._moveVector -= this.playerModel.forward;
        if (this._d) this._moveVector += this.playerModel.right;
    }

    void FixedUpdate() {
        // Moving
        this._characterController.Move(this._moveVector * this.moveSpeed * Time.fixedDeltaTime);
        // Falling
        this._characterController.Move(Vector3.down * this._fallVelocity * Time.fixedDeltaTime);
        this._fallVelocity += this.gravity * Time.fixedDeltaTime;

        if (_characterController.isGrounded) this._fallVelocity = 0;
    }
}
