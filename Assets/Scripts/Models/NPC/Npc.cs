using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    [SerializeField] string npcName;
    [SerializeField] float baseSpeed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] PathPoint startPoint;
    Rigidbody rb;

    public string CurrentScene = "";

    public void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        agent.enabled = false;
        CurrentScene = startPoint.Scene;
        this.Name = npcName;
        this.ToStartPoint();
        agent.enabled = true;
        agent.speed = baseSpeed;
        //WorldTime.DayEndedEvent += ToStartPoint;
    }

    public void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            OffMeshLinkData data = agent.currentOffMeshLinkData;

            //calculate the final point of the link
            Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;

            Vector3 destination = agent.destination;
            //Move the agent to the end point
            agent.Warp(endPos);

            agent.CompleteOffMeshLink();  
            
            agent.SetDestination(destination);
        }
    }

    public string Name { get; set; }

    private void EnableAgent()
    {
        agent.enabled = true;
    }
    private void DisableAgent()
    {
        agent.enabled = false;
    }

    public void SetBaseSpeed()
    {
        agent.speed = baseSpeed;
    }
    public void Warp(Vector3 position)
    {
        Vector3 destination = agent.destination;
        //Move the agent to the end point
        agent.Warp(position);
        agent.SetDestination(destination);
    }

    public void MoveByPathPoint(PathPoint point)
    {
        //agent.Warp(point.GetPosition());
        //agent.Move(point.GetPosition());
        //agent.isStopped = false;
        //agent.enabled = false;
        //CurrentScene = point.Scene;
        //this.gameObject.transform.position = point.GetPosition();
        //agent.isStopped = true;
        //agent.enabled = true;
    }
    public void MoveToDestination(Vector3 transform)
    {
        if (agent.enabled && !agent.isStopped)
        {
            agent.SetDestination(transform);
        }
    }
    public void StopMoving()
    {
        if (agent.enabled)
        {
            agent.isStopped = true;
        }
    }
    public void StartMoving()
    {
        if (agent.enabled)
        {
            agent.isStopped = false;
        }
    }
    public void ToStartPoint()
    {
        this.gameObject.transform.position = startPoint.GetPosition();
    }
}
