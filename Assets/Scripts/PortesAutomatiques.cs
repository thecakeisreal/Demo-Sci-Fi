using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ouverture et fermeture des portes automatiques
public class PortesAutomatiques : MonoBehaviour
{
    // Controleur d'animation de la porte
    private Animator animatorPorte;

    private void Start()
    {
        animatorPorte = transform.Find("Porte").GetComponent<Animator>();
        if(animatorPorte == null)
        {
            Debug.Log("L'enfant nommé Porte devrait avoir un composant Animator");
        }
    }

    // Le joueur approche la porte
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animatorPorte.SetBool("character_nearby", true);
        }
    }

    // Le joueur s'éloigne de la porte
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animatorPorte.SetBool("character_nearby", false);
        }
    }
}
