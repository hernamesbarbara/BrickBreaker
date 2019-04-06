using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float minPaddleX = 1f;
    [SerializeField] public float maxPaddleX = 15f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float mousePosXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosXInUnits, minPaddleX, maxPaddleX);
        transform.position = paddlePos;
    }
}
