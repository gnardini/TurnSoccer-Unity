using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player1TurnIndicator;
    public GameObject player2TurnIndicator;
    public Text result;
    public GameObject player;

    private int _playersTurn;
    private int[] _playerGoals;

    private GameObject _ball;
    private List<GameObject> _players;

	// Use this for initialization
	void Start () {
        _ball = GameObject.Find("soccer-ball");
        _players = new List<GameObject>();

        int xDist = 500;
        int yDist = 60;
        createPlayer(new Vector3(-xDist, yDist, 0), 1);
        createPlayer(new Vector3(-xDist, -yDist, 0), 1);
        createPlayer(new Vector3(xDist, yDist, 0), 2);
        createPlayer(new Vector3(xDist, -yDist, 0), 2);

        _playersTurn = 1;

        _playerGoals = new int[2];
        _playerGoals[0] = 0;
        _playerGoals[1] = 0;
	}
	
    void createPlayer(Vector3 position, int playerNumber) {
        var playerPlaceHolder = (GameObject) Instantiate(player, position, Quaternion.identity);
        playerPlaceHolder.GetComponent<Player>().setPlayerNumber(playerNumber);
        playerPlaceHolder.GetComponent<Player>().setInitialPosition(position);
        playerPlaceHolder.GetComponent<Player>().setGameManager(this);
        playerPlaceHolder.GetComponent<SpriteRenderer>().color = playerNumber == 1 ? Color.red : Color.blue;
        _players.Add(playerPlaceHolder);
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void changeTurn() {
        _playersTurn = 3 - _playersTurn;
        bool player1Turn = isPlayersTurn(1);
        player1TurnIndicator.SetActive(player1Turn);
        player2TurnIndicator.SetActive(!player1Turn);
    }

    public bool isPlayersTurn(int playerNumber) {
        return _playersTurn == playerNumber;
    }

    public void goal(int playerGoal) {
        foreach(GameObject playerGO in _players) {
            playerGO.GetComponent<Player>().restartPosition();
        }
        _ball.transform.position = Vector3.zero;
        _ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _ball.GetComponent<Rigidbody2D>().angularVelocity = 0;

        _playerGoals[playerGoal - 1]++;
        result.text = _playerGoals[0] + " - " + _playerGoals[1];
    }

}
