using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUserInterface : MonoBehaviour
{
    public InputField inputName;
    
    private void SavePlayerName()
    {
        DataPersistence.Instance.playerName = inputName.text;
    }

    public void StartGame()
    {
        SavePlayerName();
        SceneManager.LoadScene(1);
    }
}
