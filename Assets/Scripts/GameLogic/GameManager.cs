using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[Header("Add every portal in the scene to list")]
	public PortalController[] myPortalControllers;
	[Header("Name of the next level to load when you finish")]
	public string levelToLoad = "";
	[Header("How many Collectable objects in the scene?")]
	public int numToCollect = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckComplete();
	}

	void CheckComplete()
	{
		bool isComplete = true;
		if(numToCollect > 0)
			isComplete = false;
		for(int i = 0; i < myPortalControllers.Length; i++)
		{
			if(!myPortalControllers[i].isTarget)
			{
				isComplete = false;
			}
		}

		if(isComplete)
		{
			SceneManager.LoadScene(levelToLoad);

		}
	}
}
