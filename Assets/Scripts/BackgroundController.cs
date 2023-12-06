using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private GameController gameController;
    private readonly float movementSpeedModifier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += gameController.PlayerSpeed * movementSpeedModifier * Time.deltaTime * Vector3.left;

        if (gameObject.transform.position.x < -15)
        {
            gameObject.transform.position += Vector3.right * 30;
        }
    }
}
