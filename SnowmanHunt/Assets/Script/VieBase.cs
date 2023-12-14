using UnityEngine;
using System.Collections.Generic;

public class VieBase : MonoBehaviour
{
    [SerializeField] private List<GameObject> cadeauxList;
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
            UpdateCadeaux();
        }
        else if (other.CompareTag("EnemiKamy"))
        {
            Debug.Log("EnnemiKamy détecté");
            PerdreVie(30);
            UpdateCadeaux();
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

    void UpdateCadeaux()
    {
        // Mettez à jour la liste des cadeaux en la réduisant progressivement
        if (cadeauxList.Count > 0)
        {
            int indexCadeau = Random.Range(0, cadeauxList.Count);
            GameObject cadeau = cadeauxList[indexCadeau];
            
            // Supprimez le cadeau de la liste
            cadeauxList.RemoveAt(indexCadeau);

            // Supprimez le cadeau du jeu
            Destroy(cadeau);

            if (cadeauxList.Count == 0)
            {
                Time.timeScale = 0f;
            }
        }
    }
}
