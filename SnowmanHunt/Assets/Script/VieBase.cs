using UnityEngine;

public class VieBase : MonoBehaviour
{
    public int vieInitiale = 100;  // La vie initiale de la base
    private int vieActuelle;       // La vie actuelle de la base

    void Start()
    {
        vieActuelle = vieInitiale;
    }

    void Update()
    {
        Debug.Log("Vie actuelle de la base : " + vieActuelle);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            Debug.Log("Ennemi détecté");
            PerdreVie(10);
        }
    }

    void PerdreVie(int quantite)
    {
        vieActuelle -= quantite;

        // Mettez ici la logique pour la mise à jour de l'interface utilisateur ou tout autre effet visuel

        if (vieActuelle <= 0)
        {
            // Mettez ici la logique pour gérer la destruction ou la désactivation de la base
            // Par exemple, désactivez la base, affichez un écran de fin de partie, etc.
            // Vous pouvez également recharger le niveau ou faire d'autres actions en conséquence.
        }
    }
}
