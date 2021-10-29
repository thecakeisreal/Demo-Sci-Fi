using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Etat projecteur", menuName = "Jeu/Etat projecteur")]
public class EtatProjecteur : ScriptableObject
{
    public bool afficherLumiere;

    public string objetAffiche;
}
