using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gmscene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score:"+playermovm.score);
    }

    // Update is called once per frame
    void Update()
    {
     	    
    }
    public void retry()
    {
    	SceneManager.LoadScene("SampleScene");
    }
}
