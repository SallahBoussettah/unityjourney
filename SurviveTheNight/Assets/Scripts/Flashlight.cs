using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public Light spotLight;
    public float range = 20f;
    RaycastHit hit;
    EnemyFollow lastEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spotLight.enabled = !spotLight.enabled;
        }

        if(spotLight.enabled)
        {
            if (lastEnemy != null)
            {
                lastEnemy.isLit = false;
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
                {
                    lastEnemy = hit.collider.GetComponent<EnemyFollow>();
                    if (lastEnemy != null)
                    {
                        lastEnemy.isLit = true;
                    }
                }
        }
    }
}
