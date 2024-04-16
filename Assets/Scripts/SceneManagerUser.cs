using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerUser : MonoBehaviour
{
    private DataManager dataManager;
    private DataSave dataSave;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        dataManager = GetComponent<DataManager>();
        dataManager.LoadProgress();
        dataSave = dataManager.dataSave;
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene("Level " + (dataSave.numberCompletedLevels + 1));
    }
    public void PlayMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
public class DataSave
{
    public int numberCompletedLevels = 0;
}
