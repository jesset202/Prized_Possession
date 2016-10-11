using UnityEngine;
using System.Collections;

public class Altar : MonoBehaviour
{
    public GameObject prefabPlayer;
    public GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (players.Length == 2)
        {
            if (col.gameObject.tag == "Player")
            {

                if (col.gameObject == players[0])
                {
                    players[0].GetComponent<Player>().myRole = Player.Role.Chaser;
                    players[1].GetComponent<Player>().myRole = Player.Role.Runner;
                    Destroy(this.gameObject);
                }
                if (col.gameObject == players[1])
                {
                    players[0].GetComponent<Player>().myRole = Player.Role.Runner;
                    players[1].GetComponent<Player>().myRole = Player.Role.Chaser;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
