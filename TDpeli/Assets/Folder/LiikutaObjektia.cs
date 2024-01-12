using UnityEngine;

public class LiikutaObjektia : MonoBehaviour
{
    public float nopeus = 5f; // Määrittele objektin liikkumisnopeus

    void Update()
    {
        Liikuta();
    }

    void Liikuta()
    {
        // Hae objektin nykyinen sijainti
        Vector3 sijainti = transform.position;

        // Liikuta objektia oikealle
        sijainti.x += nopeus * Time.deltaTime;

        // Jos objekti on siirtynyt ruudun reunasta toiselle, aseta se takaisin alkupisteeseen
        if (sijainti.x > Screen.width)
        {
            sijainti.x = 0;
        }

        // Aseta objektin uusi sijainti
        transform.position = sijainti;
    }
}