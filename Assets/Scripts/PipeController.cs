using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private GameController gameController;

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
        if (gameObject.transform.position.x < -10)
        {
            Destroy(gameObject);

        } else {
            gameObject.transform.position += Time.deltaTime * gameController.PlayerSpeed * Vector3.left;
        }
    }
}
