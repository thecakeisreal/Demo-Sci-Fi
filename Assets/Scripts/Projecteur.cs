using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projecteur du laboratoire
public class Projecteur : ObjetInteragissable
{
    // Permet de changer l'�tat du projecteur
    protected override void EffectuerAction()
    {
        Debug.Log("Interaction");
    }
 }
