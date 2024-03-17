using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
    public float rotationSpeed;
    public float maxVerticalAngle;
    public float minVerticalAngle;

    private float _newRotX;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        this.transform.localEulerAngles = new Vector3(
            this.transform.localEulerAngles.x,
            this.transform.localEulerAngles.y + this.rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"),
            0
        );
        this._newRotX = this.transform.localEulerAngles.x - this.rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if (this._newRotX < this.maxVerticalAngle || this._newRotX > 360+this.minVerticalAngle)
            this.transform.localEulerAngles = new Vector3(
                this._newRotX,
                this.transform.localEulerAngles.y, 0
            );
    }
}
