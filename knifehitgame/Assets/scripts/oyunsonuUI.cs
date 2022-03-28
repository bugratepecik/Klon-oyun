using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class oyunsonuUI : MonoBehaviour
{
    public GameObject tekrarButonu;
    public void tekrarOyna()
    {

        SceneManager.LoadScene(0);

    }
}
