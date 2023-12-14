using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform cible;
    public float vitesseDeplacement = 1f;

    void Start()
    {
        cible = GameObject.Find("Cible").transform;
    }

    void Update()
    {
        // Calculer la direction vers le point cible
        Vector3 direction = cible.position - transform.position;

        // Ignorer la rotation sur l'axe Y (pour éviter de tourner l'ennemi sur lui-même)
        direction.y = 0;

        // Normaliser la direction pour maintenir la vitesse de déplacement constante
        direction.Normalize();

        // Utiliser LookAt pour orienter l'objet vers la cible
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500f);
        }

        // Déplacer l'objet vers le point cible
        transform.Translate(Vector3.forward * vitesseDeplacement * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boule"))
        {
            Destroy(gameObject);
            Debug.Log("Touché");
        }
        
    }
}
