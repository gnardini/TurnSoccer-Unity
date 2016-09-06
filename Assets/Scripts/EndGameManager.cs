using UnityEngine;
using System.Collections;

public class EndGameManager : MonoBehaviour {

    public static int winnerPlayer;

    private static float SECONDS_TO_MENU = 5f;

    private float _timePassed;

	void Start () {
        GameObject.Find("Player" + winnerPlayer).SetActive(true);
        GameObject.Find("Player" + (3 - winnerPlayer)).SetActive(false);
	}

    void Update() {
        _timePassed += Time.deltaTime;
        if (_timePassed > SECONDS_TO_MENU) {
            Application.LoadLevel("Menu");
        }
    }
	
}
