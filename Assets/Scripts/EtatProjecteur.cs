using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EtatProjecteur", menuName = "Jeu/Etat Projecteur")]
public class EtatProjecteur : ScriptableObject
{
    public bool lumiereAllumee;

    public string gameObjectActif;

}
