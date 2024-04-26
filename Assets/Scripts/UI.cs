using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private SceneManagerUser sceneManagerUser;
    private DataManager dataManager;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelWin;
    void Start()
    {
        sceneManagerUser = FindObjectOfType<SceneManagerUser>();
        dataManager = FindObjectOfType<DataManager>();
    }

    public void PlayLevel() => sceneManagerUser.PlayLevel();
    public void PlayMenu() => sceneManagerUser.PlayMenu();
    public void PlayNextLevel() => sceneManagerUser.PlayNextLevel();
    public void PanelGameOver() => panelGameOver.SetActive(true);

    public void PanelWin() => panelWin.SetActive(true);
}
