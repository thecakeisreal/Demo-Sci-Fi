using UnityEngine;

public class ControleurPersonnage : MonoBehaviour
{
    [Header("Partie du corps")]
    // Références aux parties du corps
    public GameObject tete;
    public GameObject torse;
    // Ajouter les autres parties que vous gérez....

    [Header("Contrôles")]
    // Touches de contrôle
    // Dans un monde idéal, ces touches sont dans une classe dédiée pour faciliter leur gestion
    public KeyCode avancer = KeyCode.W;
    public KeyCode reculer = KeyCode.S;
    public KeyCode droite = KeyCode.D;
    public KeyCode gauche = KeyCode.A;
    public KeyCode courir = KeyCode.LeftShift;

    public float sensibiliteSouris = 0.5f;
    // Possibilité d'ajouter un booléen pour gérer l'inversion de l'axe Y

    [Header("Caractéristiques")]
    public float vitesse;
    public float vitesseRotation;
    public float amplitudeCou;  // Angle en degré que l'on peut regarder en haut/en bas

    // On manipule la physique, donc il est préférable de le faire dans FixedUpdate
    void FixedUpdate()
    {
        // Dans un mode de prod réel, on veut éviter de faire des méthodes Update trop volumineuse
        // Son rôle devrait être de déclencher des traitements à chaque frame
        // Si le traitement est court, on peut le réaliser à cet endroit
        // Voyez-la un peu comme un Main d'un programme
        DeplacerPersonnage();
    }

    void DeplacerPersonnage()
    {
        float vitesse = this.vitesse;
        if(Input.GetKey(courir))    // En courrant on va 3x plus vite
        {
            vitesse *= 3f;
        }

        // Déplacement du personnage
        if (Input.GetKey(avancer))
        {
            // Le vecteur Forward ici prend la direction dans laquelle le personnage regarde vers l'avant
            transform.position += transform.forward * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(reculer))
        {
            transform.position -= transform.forward * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(droite))
        {
            // Le vecteur Forward ici prend la direction dans laquelle le personnage regarde vers l'avant
            transform.position += transform.right * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(gauche))
        {
            transform.position -= transform.right * vitesse * Time.deltaTime;
        }

        // Attention Axis horizontal et vertical traitent des touches W A S D
        // Utile si vous voulez rendre votre jeu portable sur console !
        // Remarquez trois choses : 
        // Inversion X et Y (mouvement de la souris en Y cause une rotation autour de l'axe des X)
        // Inversion du mouvement en Y (*-1) (trouvez pourquoi !)
        // On tourne le personnage en Y (rotation complète), donc forward reste devant
        // Mais on tourne juste la tête de haut en bas (idéalement le "fusil" devrait suivre...)

        // Tête haut / bas
        float rotationX = Input.GetAxis("Mouse Y");
        tete.transform.Rotate(-1 * rotationX * sensibiliteSouris * Time.deltaTime, 0f, 0f);

        float angleTete = tete.transform.localRotation.eulerAngles.x;
        // On positionne la tête dans l'intervalle demandée
        if (angleTete > amplitudeCou && angleTete < 180f)
        {
            tete.transform.localRotation = Quaternion.Euler(amplitudeCou, 0f, 0f);
        }
        // Les angles négatifs sont traités de façon positive par eulerAngles (toujours sur l'intervalle 0 - 360)
        if (angleTete < 360f - amplitudeCou && angleTete > 180f)
        {
            tete.transform.localRotation = Quaternion.Euler(-amplitudeCou, 0f, 0f);
        }

        // Corps gauche / droite
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(0f, rotationY * vitesseRotation * Time.deltaTime, 0f);
    }
}