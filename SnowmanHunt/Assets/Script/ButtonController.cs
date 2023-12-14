using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    public Color active;
    public Color normal;
    public ButtonType type;
    public TextMeshProUGUI TextMeshPro;
    [SerializeField] private AudioSource Click;

    public enum ButtonType
    {
        JOUER, CREDITS, QUITTER, MENU
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color=active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color=normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case ButtonType.JOUER:
                Debug.Log("Jouer");
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                Click.Play();
            break;
            case ButtonType.CREDITS:
                Debug.Log("Credits");
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                Click.Play();
            break;
            case ButtonType.QUITTER:
                Debug.Log("Quitter");
                Click.Play();
                Application.Quit();
            break;
            case ButtonType.MENU:
                Debug.Log("Menu");
                Click.Play();
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            break;
        }
    }
    
}
