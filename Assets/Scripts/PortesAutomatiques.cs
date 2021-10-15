using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ouverture et fermeture des portes automatiques
public class PortesAutomatiques : MonoBehaviour
{
    // Controleur d'animation de la porte
    private Animator animatorPorte;

    // Référence sur la source audio
    private AudioSource sourceAudio;

    // Clips audio
    public AudioClip ouverturePorte;
    public AudioClip fermeturePorte;

    private void Start()
    {
        animatorPorte = transform.Find("Porte").GetComponent<Animator>();
        sourceAudio = transform.Find("Porte").GetComponent<AudioSource>();

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

            sourceAudio.clip = ouverturePorte;
            sourceAudio.Play();
        }
    }

    // Le joueur s'éloigne de la porte
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animatorPorte.SetBool("character_nearby", false);

            sourceAudio.clip = fermeturePorte;
            sourceAudio.Play();
        }
    }
}
