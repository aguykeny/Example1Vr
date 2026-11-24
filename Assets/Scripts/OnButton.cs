using UnityEngine;

public class OnButton : MonoBehaviour
{
    public void OnButtonDown()
    {
        SceneLoader.instance.LoadScene("GameScene");
    }
}
