using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _timerText;

	private void Awake()
	{
		_timerText.text = Time.timeSinceLevelLoad + "";
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}

}
