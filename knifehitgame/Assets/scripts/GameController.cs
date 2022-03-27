using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioClip nextLevelEffect;
    public GameObject restartButton;
    public GameObject nextLevelButton;
    public static GameController Instance { get; private set; }
    [SerializeField]
    private int knifeCount;
    [Header("Knive Spawning")]
    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private GameObject knifeObject;
  
    
 

    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
    }

    public void OnSuccessfulKnifeHit()
    {
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void StartGameOverSequence()
    {
        throw new NotImplementedException();
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(1f);
            Audio.PlayOneShot(nextLevelEffect);
            nextLevelButton.SetActive(true);
        }
        else
        {
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
