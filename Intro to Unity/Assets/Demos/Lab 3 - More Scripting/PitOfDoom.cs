using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    public void LoadSceneByName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void GoBackToTitleScene()
    {
        LoadSceneByName("Title");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

public class GameManager : MonoBehaviour
{
    public bool hasPlayerCompletedTheFirstTask = false;
    public GameObject referenceToThePlayer;
    public int numberOfFlowerPotsLeftToWater = 5;

    public static GameManager Instance = null;
    private void Awake()
    {
        // You might consider keeping the GameManager from getting destroyed
        // when you change scenes and preventing multiple from existing.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        // Other scripts can now access me with GameManager.Instance instead
        // of having to find the game manager on Start
    }
}


public class PitOfDoom : MonoBehaviour
{
    public Transform RespawnPosition;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.DoStuff();
    }


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = RespawnPosition.position;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.rotation = Random.rotation;
    }
}
