using SleepingDaemon.EncryptorSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;
    public LayerMask primerMask;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            var ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Debug.Log(hit.collider.name);

                if (hit.collider != null)
                {
                    Debug.Log("Hit Success");
                    var primer = hit.collider.transform.GetComponent<LanguagePrimer>();
                    if (primer != null)
                    {
                        primer.AddLetters();
                        primer.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("Did not hit a collider");
                }
            }
        }
    }
}
