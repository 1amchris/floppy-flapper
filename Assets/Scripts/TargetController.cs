using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour
{
    private GameController gameController;

    public void Start()
    {
        gameController = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        gameController.AddScore();
    }
}
