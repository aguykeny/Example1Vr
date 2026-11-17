using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject stone;
    bool playerDetected; //Si ha detectado el jugador dentro del Capsule Collider
    public float cadency; // Cadencia entre ataque y ataque
    public Transform shootPoint;
    public float shootForce;
    public int health;
    public Slider sliderHealth;


    private void Start()
    {
        sliderHealth.value = sliderHealth.maxValue = health;
    }
    private void OnTriggerEnter(Collider x)
    {
        if (x.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Attack");
        }
    }
    private void OnTriggerExit(Collider x)
    {
        if (x.gameObject.CompareTag("Player"))
        {
            StopCoroutine("Attack");
        }
    }
    //Corrutina
    public IEnumerator Attack()
    {
        while (true)
        {
            //Hacemos que el enemigo mire al jugador
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            //Esperamos antes de atacar
            yield return new WaitForSeconds(0.2f);
            GetComponent<Animator>().Play("Attack");
            yield return new WaitForSeconds(cadency);

        }
    }
    public void ShootStone()
    {
        Instantiate(stone, shootPoint.position, shootPoint.rotation)
        .GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);

    }
    private void OnCollisionEnter(Collision x)
    {
        Debug.Log(x.gameObject.tag);
        if (x.gameObject.CompareTag("Weapon"))
        {
            health--;
            sliderHealth.value = health;
            Debug.Log("Contacto");
            Debug.Log(health);
            if (health <= 0)
            {
                //Paramos las corrutinas
                StopAllCoroutines();
                //el objeto no será manejado por el motor de física
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Animator>().Play("Dying");
                //Deshabilitamos este script
                this.enabled = false;
            }
        }
    }
}