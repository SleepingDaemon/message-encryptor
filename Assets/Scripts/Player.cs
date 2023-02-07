using SleepingDaemon.EncryptSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;
    public LayerMask layerMask;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, layerMask);
            if (hit)
            {
                if (hit.collider != null)
                {
                    var primer = hit.collider.transform.GetComponent<LanguagePrimer>();

                    if (primer != null)
                    {
                        primer.AddLetters();
                        primer.gameObject.SetActive(false);
                    }

                    var message = hit.collider.transform.GetComponent<Message>();

                    if (message != null)
                    {
                        message.InitMessage();
                        message.transform.GetChild(0).gameObject.SetActive(false);
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
