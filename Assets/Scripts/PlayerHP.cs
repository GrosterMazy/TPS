using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {
    public float value = 100;
    public RectTransform valueRectTransform;

    public GameObject inGameUI;
    public GameObject gameOverScreen;
    public CameraRotation cameraRotation;
    public CameraZoom cameraZoom;

    private float _maxValue;

    void Start() {
        this._maxValue = this.value;
    }

    public void DealDamage(float damage) {
        this.value -= damage;
        if (this.value <= 0) {
            this.inGameUI.SetActive(false);
            this.gameOverScreen.SetActive(true);

            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponent<PlayerCast>().enabled = false;
            this.GetComponent<PlayerAim>().enabled = false;
            this.cameraRotation.enabled = false;
            this.cameraZoom.enabled = false;
        }

        this.DrawHPBar();
    }
    public void Heal(float heal) {
        this.value += heal;
        if (this.value > this._maxValue)
            this.value = this._maxValue;

        this.DrawHPBar();
    }

    void DrawHPBar() {
        this.valueRectTransform.anchorMax = new Vector2(this.value/this._maxValue, 1);
    }
}
