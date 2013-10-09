using UnityEngine;
using System.Collections;

[System.Serializable]
public class SignalSender{

	public bool onlyOnce ;
	public ReceiverItem[] receivers = null;
	
	private bool hasFired = false;
	
	public void SendSignals (MonoBehaviour sender) 
	{
		if (hasFired == false || onlyOnce == false) 
		{
			if(receivers != null)
			{
				for (var i = 0; i < receivers.Length; i++) 
				{
					sender.StartCoroutine (receivers[i].SendWithDelay(sender));
				}
				hasFired = true;
			}
		}
	}
}

[System.Serializable]
public class ReceiverItem 
{
	public GameObject receiver;
	public string action = "OnSignal";
	public float delay;
	
	public IEnumerator SendWithDelay (MonoBehaviour sender) {
		 yield return new WaitForSeconds(delay);
		if (receiver)
			receiver.SendMessage (action);
		else
			Debug.LogWarning ("No receiver of signal \""+action+"\" on object "+sender.name+" ("+sender.GetType().Name+")", sender);
	}
}

