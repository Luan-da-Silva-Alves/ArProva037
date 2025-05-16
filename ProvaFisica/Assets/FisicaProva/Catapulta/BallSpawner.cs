using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    public List<GameObject> balls;

    public Lancamento catapulta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !catapulta.isLaunching)
        {
            Instantiate(balls[Random.Range(0, balls.Count)]);
        }
    }
}
