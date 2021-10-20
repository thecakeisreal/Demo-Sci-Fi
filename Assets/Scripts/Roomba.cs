using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Roomba : MonoBehaviour
{
    public GameObject piece;

    private Bounds limitesPiece;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        limitesPiece = new Bounds(piece.transform.position, Vector3.zero);

        foreach(MeshRenderer rendererEnfant in piece.transform.GetComponentsInChildren<MeshRenderer>())
        {
            limitesPiece.Encapsulate(rendererEnfant.bounds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator GenererProchaineDestinationCoroutine()
    {
        yield return null;
    }

    private Vector3 GenererPositionAleatoire()
    {
        return Vector3.zero;
    }

    // Dessine dans la scène
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limitesPiece.center, limitesPiece.size);
    }
}
