using UnityEngine;

// Projecteur du laboratoire
public class Projecteur : ObjetInteragissable
{
    public Light lumiere;

    public GameObject parentComposantsProjecteur;

    public EtatProjecteur[] etatsProjecteur;

    private int etatActuel;

    private void Start()
    {
        etatActuel = 0;
        ChangerEtat(etatActuel);
    }

    private void ChangerEtat(int indexEtat)
    {
        if(indexEtat < 0 || indexEtat >= etatsProjecteur.Length)
        {
            return;
        }

        EtatProjecteur etat = etatsProjecteur[indexEtat];

        lumiere.gameObject.SetActive(etat.lumiereAllumee);
        foreach(Transform enfant in parentComposantsProjecteur.transform)
        {
            enfant.gameObject.SetActive(enfant.name == etat.gameObjectActif);
        }
    }

    // Permet de changer l'état du projecteur
    protected override void EffectuerAction()
    {
        etatActuel = (etatActuel + 1) % etatsProjecteur.Length;
        ChangerEtat(etatActuel);
    }
 }
