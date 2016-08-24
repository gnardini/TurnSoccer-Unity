using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameManager gameManager;
    public int playerGoal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.name.Equals("soccer-ball")) {
            gameManager.goal(playerGoal);
        }
    }

}
