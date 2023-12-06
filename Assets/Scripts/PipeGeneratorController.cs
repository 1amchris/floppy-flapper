using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneratorController : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1;
    public float pipeMaxOffset = 1.7f;

    private float timer = 0;
    private float initialSpeed;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
        initialSpeed = gameController.PlayerSpeed;

        GeneratePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.PlayerIsAlive)
            return;

        if (ShouldGeneratePipe())
        {
            GeneratePipe();
            timer = 0;

        } else
        {
            timer += Time.deltaTime;
        }
    }

    private void GeneratePipe()
    {
        var randomOffset = Random.Range(-pipeMaxOffset, +pipeMaxOffset);
        var position = gameObject.transform.position + new Vector3(0, randomOffset, 0);
        Instantiate(pipe, position, gameObject.transform.rotation);
    }

    private bool ShouldGeneratePipe()
    {
        return initialSpeed < spawnRate * timer * gameController.PlayerSpeed;
    }
}
