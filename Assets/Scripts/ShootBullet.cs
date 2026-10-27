using UnityEngine;
using static OVRInput;

public class ShootBullet : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Instantiate(Bullet, shootPoint.position, shootPoint.rotation)
                .GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);

                Debug.Log("Shoot!!!");
            }
        }
    }
}
