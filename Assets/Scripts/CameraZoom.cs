using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    void Update() {
        this.transform.localPosition = new Vector3(
            this.transform.localPosition.x, this.transform.localPosition.y,
            Mathf.Clamp(this.transform.localPosition.z + this.zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"), -this.maxZoom, -this.minZoom)
        );
    }
}
