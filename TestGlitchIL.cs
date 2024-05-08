using UnityEngine;

public class TestGlitchIL : MonoBehaviour, ITestGlitch
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			((ITestGlitch)this).GlitchTest(true, 1,2,3,4,5,6,7,8,9);
		}
	}
	public void GlitchTest(bool grab, params int[] inputs)
	{
		string input = string.Join(" ", inputs);
		Debug.Log("Grabbed:"+ input);
	}
	public void GlitchTest2(bool grab, params int[] inputs)
	{
		string input = string.Join(";", inputs);
		Debug.Log("UnGrabbed:" + input);
	}
}
public interface ITestGlitch
{
	public static bool GlitchMethod<T>(out T handGrabbed) where T : ITestGlitch
	{
		ITestGlitch result = null;
		handGrabbed = default(T);
		return (result is T && (handGrabbed = (T)result) != null);
	}
	public void GlitchTest(bool grab, params int[] inputs);
	public void GlitchTest2(bool grab, params int[] inputs);
}

