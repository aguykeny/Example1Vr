using System;
using UnityEngine;
using static OVRInput;

public class MoveCube : MonoBehaviour

{

    [SerializeField] private float speed = 1.04f;
    [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.RTouch;

    private Renderer cubeRenderer;




    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }


    void Update()
    {
        //moveJoystick();

        //upDownWithBottons();

        //proximitySensor();

        //triggerTest();

    }

  

    private void triggerTest()
    {
        float triggerPress = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        cubeRenderer.material.color = Color.Lerp(Color.red, Color.green, triggerPress);
    }

    private void proximitySensor()
    {
        if (OVRInput.Get(OVRInput.Touch.One, controller))
        {
            cubeRenderer.material.color = Color.green; // Verde = ¡Contacto directo!
        }
        else if (OVRInput.Get(OVRInput.NearTouch.Any, controller))
        {
            cubeRenderer.material.color = Color.yellow; // Amarillo = ¡Mano cerca en el aire!
        }
        else
        {
            cubeRenderer.material.color = Color.white; // Blanco = Reposo / Sin detectar nada
        }
    }

    private void upDownWithBottons()
    {
        if (OVRInput.Get(Button.One))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (OVRInput.Get(Button.Two))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void moveJoystick()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        transform.Translate(new Vector3(axis.x, 0, axis.y) * speed * Time.deltaTime);
    }
}
