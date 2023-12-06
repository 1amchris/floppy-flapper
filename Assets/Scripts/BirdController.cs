using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdy : MonoBehaviour
{
    public float flightVelocity = 5;

    private Rigidbody2D birdyRigidbody;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        birdyRigidbody = gameObject.GetComponent<Rigidbody2D>();

        Fly();
    }

    // Update is called once per frame
    void Update()
    {
        var verticalSpeed = birdyRigidbody.velocity.y;

        if (gameController.PlayerIsAlive && Input.GetKeyDown(KeyCode.Space))
            Fly();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameController.EndGame();
    }

    private void Fly()
    {
        birdyRigidbody.velocity = Vector2.up * flightVelocity;
    }
}
