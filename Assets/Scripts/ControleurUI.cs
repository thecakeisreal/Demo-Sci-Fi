using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gère l'affichage du UI
public class ControleurUI : MonoBehaviour
{
    public CanvasGroup aideInteraction;

    // Pseudo-singleton
    public static ControleurUI Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Affiche l'image indiquant qu'une interaction est possible
    public void AfficherInteraction()
    {
        aideInteraction.alpha = 1f;
    }

    // Masque l'image indiquant qu'une interaction est possible
    public void MasquerInteraction()
    {
        aideInteraction.alpha = 0f;
    }
}
