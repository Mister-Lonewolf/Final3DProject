using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveObject : MonoBehaviour
{
    public float speed = 16.0f;
    private float randomSpeed = 4.0f;
    private MovementDirection direction;
    private SpawnManager spawnManager;
    private float randomAngle;
    private Quaternion randomRotation;

    public enum MovementDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    // Start is called before the first frame update
    void Start()
    {
        // Willekeurig toewijzen aan direction bij het starten
        spawnManager = FindObjectOfType<SpawnManager>();
        direction = (MovementDirection)spawnManager.direction;
        speed += Random.Range(-randomSpeed, randomSpeed);
        // enum expliciet typecasten, anders werkt het niet... compiler weet niet dat enums exact hetzelfde zijn in beide klassen

    }

    // Update is called once per frame
    void Update()
    {
        // Omgekeerde logica: links gespawned? dan naar rechts bewegen, enz...
        switch (direction)
        {
            case MovementDirection.Left:
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                break;
            case MovementDirection.Right:
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                break;
            case MovementDirection.Up:
                transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
                break;
            case MovementDirection.Down:
                transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
                break;
        }
    }
}
