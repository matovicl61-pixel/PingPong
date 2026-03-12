using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Ball ball = collision.GetComponent<Ball>();

		if(ball != null) {
			BaseEventData eventData = new BaseEventData(EventSystem.current);
			this.scoreTrigger.Invoke(eventData);
		}
	}
}
