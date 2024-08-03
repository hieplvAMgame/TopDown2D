using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigate : MonoBehaviour
{
    private NavMeshAgent agent;
    public bool showPath;
    public bool showAhead;
    public float speedRotation; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    [SerializeField] public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (!InGameManager.Instance.isGameStart)
        {
            target = null;
            return;
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    target.z = 0;
        if (target)
        {
            agent.destination = target.position;
            Vector3 dir = target.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            float zRot = Mathf.Lerp(transform.localEulerAngles.z, angle, speedRotation);
            transform.localEulerAngles = Vector3.forward * zRot;
        }
        //}
    }
    public static void DebugDrawPath(Vector3[] corners)
    {
        if (corners.Length < 2) { return; }
        int i = 0;
        for (; i < corners.Length - 1; i++)
        {
            Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
        }
        Debug.DrawLine(corners[0], corners[1], Color.red);
    }

    private void OnDrawGizmos()
    {
        DrawGizmos(agent, showPath, showAhead);
    }

    public static void DrawGizmos(NavMeshAgent agent, bool showPath, bool showAhead)
    {
        if (Application.isPlaying && agent != null)
        {
            if (showPath && agent.hasPath)
            {
                var corners = agent.path.corners;
                if (corners.Length < 2) { return; }
                int i = 0;
                for (; i < corners.Length - 1; i++)
                {
                    Debug.DrawLine(corners[i], corners[i + 1], Color.blue);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(agent.path.corners[i + 1], 0.03f);
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
                }
                Debug.DrawLine(corners[0], corners[1], Color.blue);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(agent.path.corners[1], 0.03f);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(agent.path.corners[0], agent.path.corners[1]);
            }

            if (showAhead)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(agent.transform.position, agent.transform.up * 0.5f);
            }
        }
    }
}
