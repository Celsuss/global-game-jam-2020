using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

    public Transform Pos;
    public GameObject Player;

    public void Restart() {
        Application.LoadLevel(0);
    }

    public void TeleportToStart() {
        Player.transform.position = Pos.position;
        Player.transform.rotation = Pos.rotation;
    }
}
