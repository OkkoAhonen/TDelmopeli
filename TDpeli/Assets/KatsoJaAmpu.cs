using UnityEngine;

public class KatsoJaAmpu : MonoBehaviour
{
    public Transform liikkuvaObjekti;
    public GameObject ammuksenPrefab;
    public float ampumisNopeus = 5f;
    public float ampumisVali = 1f; // Ampumisen väliaika sekunteina

    private float aikaSeuraavalleAmmukselle = 0f;

    void Update()
    {
        if (liikkuvaObjekti != null)
        {
            KatsoLiikkuvaanObjektiin();

            // Ampuminen
            if (Time.time >= aikaSeuraavalleAmmukselle)
            {
                Ammu();
                aikaSeuraavalleAmmukselle = Time.time + ampumisVali;
            }
        }
    }

    void KatsoLiikkuvaanObjektiin()
    {
        Vector3 suunta = liikkuvaObjekti.position - transform.position;
        float kulma = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg;
        Quaternion uusiRot = Quaternion.Euler(new Vector3(0, 0, kulma));
        transform.rotation = Quaternion.Slerp(transform.rotation, uusiRot, Time.deltaTime);
    }

    void Ammu()
    {
        // Luo ammus prefabista ja suuntaa se kohti liikkuvaa objektia
        GameObject ammus = Instantiate(ammuksenPrefab, transform.position, Quaternion.identity);
        Vector2 suunta = liikkuvaObjekti.position - transform.position;
        ammus.GetComponent<Rigidbody2D>().velocity = suunta.normalized * ampumisNopeus;

        // Tuhoaa ammuksen, jos se ei osu kohteeseen tietyn ajan kuluttua
        Destroy(ammus, 2f);
    }
}
