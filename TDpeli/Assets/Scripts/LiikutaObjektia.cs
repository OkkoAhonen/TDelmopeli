using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LiikutaObjektia : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    public int waypointIndex;

    public Vector3 waypointPosition;

    private Transform path;
    private GameManager gameManager;

    private void Start()
    {
        path = GameObject.Find("Path").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            gameManager.TakeDamage(enemyInfo.damage);
        }
    }

    void Liikuta()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypointPosition, enemyInfo.speed * Time.deltaTime);
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