using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcSchedule : MonoBehaviour //ToDo: Упростить. Убрать хардкод. Разнести по классам
{
    [SerializeField] List<Route> routes;
    [SerializeField] Npc npc;
    [SerializeField] double scheduleCoefficent = 1;
    [SerializeField] double speed = 1;

    private Route _currRoute = null;
    private PathPoint _currPoint = null;

    public void Start()
    {
        if (routes.Count > 0)
        {
            routes = routes.OrderBy(x => x.Time).ToList<Route>();
        }
    }

    public void Update()
    {
        if (routes.Count > 0)
        {
            float currentTime = WorldTime.GetCurrentTime();
            float finalTime = currentTime + PredictTime(currentTime);

            if (finalTime > 86400)
                finalTime -= 86400;

            Route route = GetByTime(finalTime);

            if (_currRoute != route)
            {
                if (_currRoute != null)
                {
                    _currRoute.Achieved = false;
                    foreach (var r in routes)
                    {
                        r.ResetAllPoints();
                    }
                }
                _currRoute = route;
            }
            //Debug.Log("ACHIEVED " + _currRoute.Achieved.ToString() + " " + _currRoute.Name);

            PathPoint point = _currRoute.GetNextPoint();

            if (_currPoint != point && point != null)
            {
                _currPoint = point;
                Vector3 transform = Vector3.zero;

                if (_currPoint != null)
                {
                    transform = _currPoint.GetPosition();
                }

                if (transform != Vector3.zero)
                {
                    //Debug.Log("Moving");
                    npc.MoveToDestination(transform);
                }
            }

            if (_currRoute.Count == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(PreviousRoute(_currRoute).GetFinal(), 0.2));
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(PreviousRoute(_currRoute).GetFinal(), 0.5));
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(PreviousRoute(_currRoute).GetFinal(), 0.8));
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(_currRoute.GetFirst(), 0.2));
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(_currRoute.GetFirst(), 0.5));
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    npc.Warp(_currRoute.GetPositionByFactor(_currRoute.GetFirst(), 0.8));
                }
            }
        }
    }

    public Route GetByTime(float time)
    {
        //Debug.Log("GET BY TIME:" + time.ToString());
        if (routes.Count == 0) return null;

        Vector3 transform = Vector3.zero;

        bool isHighestTime = false;
        Route highestTime = null;

        foreach (var point in routes)
        {
            if (time > point.Time) { highestTime = point; isHighestTime = true; }
        }

        if (isHighestTime)
            return highestTime;
        else
            return routes[routes.Count - 1];
    }

    public Route NextRoute(Route route)
    {
        if (routes.IndexOf(route) != routes.Count - 1)
        {
            return routes[routes.IndexOf(route) + 1];
        }
        else
        {
            return routes[0];
        }
    }

    public Route PreviousRoute(Route route)
    {
        if (routes.IndexOf(route) != 0)
        {
            return routes[routes.IndexOf(route) - 1];
        }
        else
        {
            return routes[routes.Count - 1];
        }
    }

    public float PredictTime(float time) //Change
    {
        Route route = GetByTime(time);
        if (route != null)
        {
            Route next = NextRoute(route);
            double length = next.GetLength(route.GetFinal());
            float predictedTime = (float)((length / speed) * scheduleCoefficent);
            //Debug.Log(predictedTime.ToString());
            return predictedTime;
        }
        return 0;
    }

}