using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _OpeningScreen;
    [SerializeField]
    private GameObject _Bird;
    [SerializeField]
    private GameObject _PipeSpawner;
public IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        _OpeningScreen.SetActive(false);
        _Bird.SetActive(true);
        yield return new WaitForSeconds(3f);
        _PipeSpawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
