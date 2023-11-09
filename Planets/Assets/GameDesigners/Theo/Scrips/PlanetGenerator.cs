using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlanetGenerator : MonoBehaviour
//{
//    public Transform player;
//    public GameObject planetPrefab;
//    public float generationDistance = 3f;
//    public float rangeSpawn = 3f;

//    void Update()
//    {
//        float distanceToPlayer = Vector3.Distance(planetPrefab.transform.position, player.position);

//        if (distanceToPlayer < generationDistance)
//        {
//            GeneratePlanet(rangeSpawn);
//            Debug.Log(planetPrefab.transform.position);
//        }
//    }

//    void GeneratePlanet(float range)
//    {
//        Vector3 randomOffset = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0f);
//        Instantiate(planetPrefab, player.position + randomOffset, Quaternion.identity);
//    }
//}

//public class PlanetGenerator : MonoBehaviour
//{
//    public Transform player;
//    public GameObject planetPrefab;
//    public float generationDistance = 3f;
//    public float rangeSpawn = 10f;
//    public int numberOfPlanets = 5; // Définissez le nombre de planètes que vous voulez générer

//    void Update()
//    {
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        if (distanceToPlayer < generationDistance)
//        {
//            GeneratePlanets(numberOfPlanets, rangeSpawn);
//        }
//    }

//    void GeneratePlanets(int count, float range)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            float angle = Random.Range(0f, 360f); // Angle aléatoire en degrés
//            float distance = Random.Range(5f, range); // Distance aléatoire du joueur

//            // Conversion des coordonnées polaires en coordonnées cartésiennes
//            float x = Mathf.Cos(angle) * distance;
//            float y = Mathf.Sin(angle) * distance;

//            Vector3 randomOffset = new Vector3(x, y, 0f);
//            Instantiate(planetPrefab, player.position + randomOffset, Quaternion.identity);
//        }
//    }
//}

public class PlanetGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject planetPrefab;
    public float generationDistance = 3f;
    public float rangeSpawn = 10f;
    public int numberOfPlanets = 5; // Définissez le nombre de planètes que vous voulez générer
    public float maxDistanceFromPlayer = 20f; // Distance maximale du joueur avant de générer un nouveau système

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < generationDistance)
        {
            GeneratePlanets(numberOfPlanets, rangeSpawn);
        }

        // Vérifiez si le joueur est trop loin et générez un nouveau système si nécessaire
        if (distanceToPlayer > maxDistanceFromPlayer)
        {
            ResetGeneratorPosition();
            GeneratePlanets(numberOfPlanets, rangeSpawn);
        }
    }

    void GeneratePlanets(int count, float range)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = Random.Range(0f, 360f); // Angle aléatoire en degrés
            float distance = Random.Range(5f, range); // Distance aléatoire du joueur

            // Conversion des coordonnées polaires en coordonnées cartésiennes
            float x = Mathf.Cos(angle) * distance;
            float y = Mathf.Sin(angle) * distance;

            Vector3 randomOffset = new Vector3(x, y, 0f);
            Instantiate(planetPrefab, transform.position + randomOffset, Quaternion.identity);
        }
    }

    void ResetGeneratorPosition()
    {
        // Réinitialisez la position du générateur à la position actuelle du joueur
        transform.position = player.position;
    }
}



