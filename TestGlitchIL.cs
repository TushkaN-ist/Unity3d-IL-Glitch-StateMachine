using System.Collections.Generic;
using UnityEngine;

public class TestGlitchIL : MonoBehaviour, ITestGlitch
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			((ITestGlitch)this).Grabbed(true, null);
		}
	}
	public void Grabbed(bool grab, params int[] inputs)
	{
		Debug.Log("Grab");
	}
	public void UnGrabbed(bool grab, params int[] inputs)
	{
		Debug.Log("Ungrab");
	}
}
public interface ITestGlitch
{
	public static Dictionary<GameObject, ITestGlitch> grabbed = new Dictionary<GameObject, ITestGlitch>();
	public static bool TryGetValue(GameObject obj, out ITestGlitch handGrabbed)
	{
		return grabbed.TryGetValue(obj, out handGrabbed);
	}
	public static bool TryGetValue<T>(GameObject obj, out T handGrabbed) where T : ITestGlitch
	{
		ITestGlitch result;
		handGrabbed = default(T);
		return TryGetValue(obj, out result) && (result is T && (handGrabbed = (T)result) != null);
	}
	public void Grabbed(bool grab, params int[] inputs);
	public void UnGrabbed(bool grab, params int[] inputs);
}

