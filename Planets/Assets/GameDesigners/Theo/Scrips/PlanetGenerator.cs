using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject planetPrefab;
    public float generationDistance = 3f;
    public float rangeSpawn = 10f;
    public int numberOfPlanets = 5;

    //void Start()
    //{
    //    GeneratePlanets(numberOfPlanets, rangeSpawn);
    //}

    void Update()
    {
        Vector3 planetPos = planetPrefab.transform.position;
        float distanceToPlayer = Vector3.Distance(planetPos, player.position);

        if (distanceToPlayer < generationDistance)
        {
            GeneratePlanets(numberOfPlanets, rangeSpawn);
        }

        Debug.Log("distanceToPlayer:" + distanceToPlayer + "generationDistance" + generationDistance + "referenceObject" + planetPos);
    }

    void GeneratePlanets(int count, float range)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = Random.Range(0f, 360f); // Angle aléatoire en degrés
            float distance = Random.Range(2f, range); // Distance aléatoire du joueur

            // Conversion des coordonnées polaires en coordonnées cartésiennes
            float x = Mathf.Cos(angle) * distance;
            float y = Mathf.Sin(angle) * distance;

            Vector3 randomOffset = new Vector3(x, y, 0f);
            Instantiate(planetPrefab, player.position + randomOffset, Quaternion.identity);
        }
    }
}



