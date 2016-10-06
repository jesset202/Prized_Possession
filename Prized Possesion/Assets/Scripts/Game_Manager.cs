using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour
{
    public GameObject prefabPlayer;
    public GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        SetControls();
    }
    
    void Update()
    {
        CheckChaserWin();
    }

    void SetControls()
    {
        players[0].GetComponent<Player>().jump = KeyCode.W;
        players[0].GetComponent<Player>().slide = KeyCode.S;

        players[1].GetComponent<Player>().jump = KeyCode.I;
        players[1].GetComponent<Player>().slide = KeyCode.K;
    }

    void CheckChaserWin()
    {
        if (players[0].GetComponent<Player>().myRole == Player.Role.Chaser)
        {
            if (players[0].transform.InverseTransformPoint(players[1].transform.position).x <= 0)
            {
                Debug.Log("Chaser1 win");
            }
        }
        
        if(players[1].GetComponent<Player>().myRole == Player.Role.Chaser)
        {
            if (players[1].transform.InverseTransformPoint(players[0].transform.position).x <= 0)
            {
                Debug.Log("Chaser2 win");
            }
        }
    }
}
