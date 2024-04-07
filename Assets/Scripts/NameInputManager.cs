using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInputManager : MonoBehaviour
{
    private InputField inputField;
    private string savedName;

    private void Start()
    {
        inputField = GetComponent<InputField>();

        // Load the player name from PlayerPrefs and set it in the input field
        savedName = PlayerPrefs.GetString("PlayerName", "Player");
        Debug.Log("Saved player name: " + savedName);
        inputField.text = savedName;

        // Subscribe to the scene loaded event to ensure input field's text is updated when changing scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event when the script is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Set the input field's text to the saved player name when a new scene is loaded
        inputField.text = savedName;
    }

    // This method is called whenever the input field text changes
    public void UpdatePlayerName(string newName)
    {
        // Update the player name in PlayerPrefs
        savedName = newName;
        PlayerPrefs.SetString("PlayerName", savedName);
        PlayerPrefs.Save(); // Ensure PlayerPrefs changes are saved immediately
        Debug.Log("Updated player name: " + savedName);
    }
}
