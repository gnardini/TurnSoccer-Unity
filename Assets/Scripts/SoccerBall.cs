using UnityEngine;
using System.Collections;

public class SoccerBall : MonoBehaviour {

    public int speed;

    private Collider2D _collider;
    private Rigidbody2D _rigidBody;

    private bool _dragging;

	// Use this for initialization
	void Start () {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (_collider.Equals(hitCollider)) {
                _dragging = true;
            }
        } else if (Input.GetMouseButtonUp(0) && _dragging) {
            _dragging = false;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diff = transform.position - mousePosition;
            _rigidBody.AddForce(diff * speed);
        }

	}

}
