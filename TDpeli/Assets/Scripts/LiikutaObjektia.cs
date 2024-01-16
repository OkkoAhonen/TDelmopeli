using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LiikutaObjektia : MonoBehaviour
{
    public float speed = 5f; // M‰‰rittele objektin liikkumisnopeus
    public int waypointIndex;

    public Vector3 waypointPosition;

    private Transform path;

    private void Start()
    {
        path = GameObject.Find("Path").transform;
        CheckAndGetWaypoint();
    }

    void Update()
    {
        if (transform.position != waypointPosition)
        {
            Liikuta();
        }
        else if (!CheckAndGetWaypoint())
        {
            Destroy(gameObject);
        }
    }

    void Liikuta()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypointPosition, speed * Time.deltaTime);
    }

    public bool CheckAndGetWaypoint()
    {
        if (path.childCount != waypointIndex)
        {
            waypointPosition = path.GetChild(waypointIndex).position;
            waypointIndex++;
            transform.right = waypointPosition - transform.position;
            return true;
        }
        else return false;
    }
}