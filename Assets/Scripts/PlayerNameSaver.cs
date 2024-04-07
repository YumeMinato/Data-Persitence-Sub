using UnityEngine;
using UnityEngine.UI;

public class PlayerNameSaver : MonoBehaviour
{
    public InputField playerNameInput; // Reference to the InputField where the player enters their name

    private void Start()
    {
        // Load the player name from PlayerPrefs and set it in the input field
        string savedName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameInput.text = savedName;

        // Listen for changes to the player name
        playerNameInput.onEndEdit.AddListener(delegate { SavePlayerName(); });
    }

    // Save the player name to PlayerPrefs when it changes
    private void SavePlayerName()
    {
        string newName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", newName);
        PlayerPrefs.Save();
    }
}
