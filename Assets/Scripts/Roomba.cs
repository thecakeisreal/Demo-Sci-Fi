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
        CalculerLimites();

        /*if (!agent.isOnNavMesh)
        {
            NavMesh.SamplePosition(transform.position, out NavMeshHit pointPlusPres, 1f, NavMesh.AllAreas);
            if (pointPlusPres.hit)
            {
                transform.position = pointPlusPres.position;
            }
            else
            {
                Debug.Log("Impossible de positionner la Roomba.");
            }
        }*/

        StartCoroutine("CalculerProchaineDestinationCoroutine");
    }

    private void CalculerLimites()
    {
        // Construit les limites de la pièce
        if (piece != null)
        {
            limitesPiece = new Bounds(piece.transform.position, Vector3.zero);
            foreach (Renderer rendererEnfant in piece.GetComponentsInChildren<MeshRenderer>())
            {
                limitesPiece.Encapsulate(rendererEnfant.bounds);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (limitesPiece != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(limitesPiece.center, limitesPiece.size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.1f)
        {
            StartCoroutine("CalculerProchaineDestinationCoroutine");
        }
    }

    private IEnumerator CalculerProchaineDestinationCoroutine()
    {
        Vector3 prochaineDestination;
        bool destinationMiseAJour = false;

        do
        {
            prochaineDestination = GenererDestination();
            if(NavMesh.SamplePosition(prochaineDestination, out NavMeshHit collisionNavMesh, 0.5f, NavMesh.AllAreas))
            {
                agent.SetDestination(prochaineDestination);
                destinationMiseAJour = true;
            }

            yield return null;
        } while (!destinationMiseAJour);
    }

    private Vector3 GenererDestination()
    {
        return new Vector3(limitesPiece.center.x + Random.Range(-limitesPiece.extents.x, limitesPiece.extents.x),
            0f, limitesPiece.center.z + Random.Range(-limitesPiece.extents.z, limitesPiece.extents.z));
    }
}
