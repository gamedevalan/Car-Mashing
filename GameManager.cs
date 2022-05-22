using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    public GameObject playerPre;
    public GameObject gameCanvas;
    public bool publicMultiplayer;
    public static bool privateMultiplayer;
    public static bool gameStarted;
    public GameObject pressButton;

    private void Start()
    {
        /* Set publicMultiplayer in inspector, set privateMultiplayer
         to be used in other classes. */
        privateMultiplayer = publicMultiplayer;
        gameStarted = false;
        pressButton.SetActive(false);
    }

    private void Update()
    {
        // Keeps checking if enough players are in the room.
        if (!gameStarted) {
            StartGame();
        }
    }

    public void SpawnCar()
    {
        PhotonNetwork.Instantiate(playerPre.name, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        pressButton.SetActive(true);
        gameStarted = true;
    }

    public void StartGame()
    {
        if (PhotonNetwork.PlayerList.Length > 1)
        {
            gameCanvas.SetActive(true);
        }
    }
}
