using Unity.VisualScripting;
using UnityEngine;

public class VelocityController : MonoBehaviour
{



    void Update()
    {
        Vector3 velocidadControlador =
        OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

        Quaternion rotacionControlador =
        OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        Vector3 posicionControlador =
        OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        float velocidad = velocidadControlador.magnitude;

        if (velocidad > 1)
        {
            Debug.Log($"Velocidad del controlador: {velocidadControlador}");
            Debug.Log($" Magnitud de la velocidad: {velocidad}");
            Debug.Log($" Rotación del controlador: {rotacionControlador}");
            Debug.Log($" Posición del controlador en X: {posicionControlador.x}");
        }
    }


}
