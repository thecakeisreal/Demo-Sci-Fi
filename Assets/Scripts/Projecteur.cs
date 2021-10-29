using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projecteur du laboratoire
public class Projecteur : ObjetInteragissable
{
    public Light lumiere;
    public GameObject contenuProjecteur;
    public EtatProjecteur[] etats;
    private int etatActuel;

    private void Start()
    {
        etatActuel = 0;
        AfficherEtat();
    }

    // Permet de changer l'état du projecteur
    protected override void EffectuerAction()
    {
        etatActuel = (etatActuel + 1) % etats.Length;
        AfficherEtat();
    }

    private void AfficherEtat()
    {
        EtatProjecteur etat = etats[etatActuel];
        lumiere.gameObject.SetActive(etat.afficherLumiere);

        foreach(Transform enfant in contenuProjecteur.transform)
        {
            if(enfant.gameObject.name == etat.objetAffiche)
            {
                enfant.gameObject.SetActive(true);
            }
            else
            {
                enfant.gameObject.SetActive(false);
            }
        }
    }
 }
