using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Starter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quitter()
    {
        Application.Quit();
    }
    public void Options()
    {

    }
    public void Wiki()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
