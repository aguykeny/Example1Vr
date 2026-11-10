using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject stone;
    bool playerDetected; //Si ha detectado el jugador dentro del Capsule Collider
    public float cadency; // Cadencia entre ataque y ataque
    public Transform shootPoint;
    public float shootForce;

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
}