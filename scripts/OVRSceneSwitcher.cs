using UnityEngine;
using UnityEngine.SceneManagement; // Allows managing scene loading

public class OVRSceneSwitcher : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void LoadScene(string sceneName)
    {
        // Loads the specified scene by name
        SceneManager.LoadScene(sceneName);
    }
}
