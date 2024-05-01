using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public Rigidbody2D bulletPlayer;
    public Transform shootPoint;
    public GameObject target;
    public bool onTurret = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onTurret = true;
            other.transform.position = shootPoint.transform.position;
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && onTurret == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow, 5);
            
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log(" Hit Point : " + hit.point);

                Vector2 projectileV = CalculateProjectile(shootPoint.position, hit.point, 1);

                bulletPlayer.constraints = ~RigidbodyConstraints2D.FreezePosition;
                bulletPlayer.velocity = projectileV;
                onTurret = false;
            }
        }
    }

    Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        Vector2 distance = targetPoint - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }


}
