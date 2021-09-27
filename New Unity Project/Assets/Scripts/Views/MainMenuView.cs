using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(InitializiGameScene);
    }

    public void InitializiGameScene()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
