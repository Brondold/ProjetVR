using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    public GameObject cible;
    public float vitesseDeplacement = 1f; // La vitesse de déplacement de l'objet

    public void Start()
    {
        cible=GameObject.Find("Cible");
    }

    void Update()
    {
        // Vérifier si l'objet a atteint le point cible
        if (transform.position != cible.transform.position)
        {
            // Calculer la direction vers le point cible
            Vector3 direction = cible.transform.position - transform.position;

            // Normaliser la direction pour maintenir la vitesse de déplacement constante
            direction.Normalize();

            // Déplacer l'objet vers le point cible
            transform.Translate(direction * vitesseDeplacement * Time.deltaTime);
        }
    }
}
