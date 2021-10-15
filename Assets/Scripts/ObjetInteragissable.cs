using System.Collections;
using UnityEngine;

// Permet d'interagir avec l'objet en utilisant la touche E
public abstract class ObjetInteragissable : MonoBehaviour
{
    private bool joueurAProximite;

    private void Awake()
    {
        joueurAProximite = false;
    }

    // Le personnage s'approche de l'objet
    private void OnTriggerEnter(Collider other)
    {
        joueurAProximite = true;
        StartCoroutine("LireToucheActionCoroutine");

        // Aide visuel
        ControleurUI.Instance.AfficherInteraction();
    }

    // Le personnage s'éloigne de l'objet
    private void OnTriggerExit(Collider other)
    {
        joueurAProximite = false;
        ControleurUI.Instance.MasquerInteraction();
    }

    // Attend pour que la touche action soit appuyée
    private IEnumerator LireToucheActionCoroutine()
    {
        while (joueurAProximite)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                EffectuerAction();
            }

            yield return null;
        }
    }

    // Action de l'objet interagissable
    protected abstract void EffectuerAction();
}
