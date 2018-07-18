using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenTransition : MonoBehaviour {
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera[] sideCams;
    public PlayerController playerController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            for (int i = 0; i < sideCams.Length; i++)
            {
                sideCams[i].gameObject.SetActive(false);
            }
            mainCam.gameObject.SetActive(true);
            StartCoroutine(TransitionPause());
        }
    }

    IEnumerator TransitionPause()
    {
        playerController.canMove = false;
        playerController.speed = 0;
        yield return new WaitForSeconds(1);
        playerController.speed = 6;
        playerController.canMove = true;
    }

}
