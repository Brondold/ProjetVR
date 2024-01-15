using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VieBase : MonoBehaviour
{
    [SerializeField] private List<GameObject> cadeauxList;
    [SerializeField] AudioSource DestroyCadeauSound;
    [SerializeField] AudioSource DammageSound;
    [SerializeField] AudioSource KamykazeSound;
    public int vieInitiale = 100;  // La vie initiale de la base
    private int vieActuelle;       // La vie actuelle de la base
    public GameObject gameOver;
    public bool GameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        vieActuelle = vieInitiale;
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            Debug.Log("Ennemi détecté");
            DammageSound.Play();
            PerdreVie(10);
            UpdateCadeaux();
        }
        else if (other.CompareTag("EnemiKamy"))
        {
            Debug.Log("EnnemiKamy détecté");
            KamykazeSound.Play();
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
            DestroyCadeauSound.Play();
            Destroy(cadeau);

            if (cadeauxList.Count == 0 && !GameOver)
            {
                GameOver = true;
                gameOver.SetActive(true);
                Time.timeScale = 0f;
                StartCoroutine(RechargerSceneAfterDelay(5f));
            }
        }
    }

    // Coroutine pour recharger la scène après un délai
    IEnumerator RechargerSceneAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        // Récupérez l'index de la scène actuelle
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Rechargez la scène actuelle
        SceneManager.LoadScene(sceneIndex);
    }
}
