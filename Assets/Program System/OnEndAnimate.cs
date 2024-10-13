using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEndAnimate : MonoBehaviour
{
    public void SwitchScene() {
        SceneManager.LoadScene("Winstreak");
    }
}
