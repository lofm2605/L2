using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private health playerHealth;
    private UImanager uiManager;
    private void Awake()
    {
        playerHealth = GetComponent<health>();
        uiManager = FindObjectOfType<UImanager>();

    }
    public void CheckRespawn()
    {
        if (currentCheckpoint == null){
            uiManager.GameOver();
            return;
        }
        else
        {
            playerHealth.Respawn();
            transform.position = currentCheckpoint.position;
            Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
