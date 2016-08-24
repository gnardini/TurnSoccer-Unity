using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int speed;

    private Collider2D _collider;
    private Rigidbody2D _rigidBody;

    private GameManager _gameManager;
    private bool _dragging;
    private int _playerNumber;
    private Vector3 _initialPosition;

	// Use this for initialization
	void Start () {
        _collider = GetComponent<Collider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!_gameManager.isPlayersTurn(_playerNumber)) {
            return;
        }
        if (Input.GetMouseButtonDown(0)) {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (_collider.Equals(hitCollider)) {
                _dragging = true;
            }
        } else if (Input.GetMouseButtonUp(0) && _dragging) {
            _dragging = false;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (_collider.Equals(hitCollider)) {
                return;
            }

            Vector3 diff = transform.position - mousePosition;
            diff *= .1f;
            diff.x *= diff.x * Mathf.Sign(diff.x);
            diff.y *= diff.y * Mathf.Sign(diff.y);

            int max = 2300;
            if (diff.magnitude > max) {
                diff *= max / diff.magnitude;
            }
            _rigidBody.AddForce(diff * speed);
            _gameManager.changeTurn();
        }

	}

    public void setPlayerNumber(int playerNumber) {
        _playerNumber = playerNumber;
    }

    public void setGameManager(GameManager gameManager) {
        _gameManager = gameManager;
    }

    public void setInitialPosition(Vector3 initialPosition) {
        _initialPosition = initialPosition;
    }

    public void restartPosition() {
        transform.position = _initialPosition;
        _rigidBody.velocity = Vector3.zero;
    }

}
