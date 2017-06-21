using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameSettings")]
    public GameObject PlayerBar;
    public Vector3 BallFromPlayerBar;
    public DeathDetection DeadZone;
    [Space(5)]

    [Header("Prefabs")]
    public GameObject BallPrefab;
    [Space(5)]

    private GameObject _ballPlayer;

    // Use this for initialization
    void Start ()
    {
        DeadZone.BallLoose += GameLoose;
		if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
            CreateNewBall();
	}

    private void CreateNewBall()
    {
        _ballPlayer = Instantiate(BallPrefab);
        _ballPlayer.transform.parent = PlayerBar.transform;
        _ballPlayer.transform.localPosition = BallFromPlayerBar;
        PlayerBar.GetComponent<PlayerInputBar>().Ball = _ballPlayer;
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    void GameLoose()
    {
        Debug.Log("loose");
        Destroy(_ballPlayer);
        CreateNewBall();
    }
}
