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

        if (piece != null)
        {
            limitesPiece = new Bounds(piece.transform.position, Vector3.zero);

            foreach (MeshRenderer rendererEnfant in piece.transform.GetComponentsInChildren<MeshRenderer>())
            {
                limitesPiece.Encapsulate(rendererEnfant.bounds);
            }

            StartCoroutine("GenererProchaineDestinationCoroutine");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.sqrMagnitude < 0.001f && piece != null)
        {
            StartCoroutine("GenererProchaineDestinationCoroutine");
        }
    }

    private IEnumerator GenererProchaineDestinationCoroutine()
    {
        bool destinationModifiee = false;

        while (!destinationModifiee)
        {
            Vector3 prochaineDestination = GenererPositionAleatoire();
            NavMesh.SamplePosition(prochaineDestination, out NavMeshHit detection, 0.2f, NavMesh.AllAreas);
            if (detection.hit)
            {
                agent.SetDestination(prochaineDestination);
                destinationModifiee = true;
            }
            yield return null;
        }
    }

    private Vector3 GenererPositionAleatoire()
    {
        return new Vector3(
            limitesPiece.center.x + Random.Range(- limitesPiece.extents.x, limitesPiece.extents.x),
            0f,
            limitesPiece.center.z + Random.Range(-limitesPiece.extents.z, limitesPiece.extents.z)
        );
    }

    // Dessine dans la scène
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limitesPiece.center, limitesPiece.size);
    }
}
