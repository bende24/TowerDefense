using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public abstract class Interactable : MonoBehaviour {

	protected bool isFocus = false;	// Is this interactable currently being focused?

	protected bool hasInteracted = false;	// Have we already interacted with the object?

	protected virtual void inRange(){
		isFocus = true;
	}
	protected virtual void outOfRange(){
		isFocus = false;
		uninteract();
	}

	// This method is meant to be overwritten
	protected virtual void interact(){
		hasInteracted = true;
	}

	protected virtual void uninteract(){
		hasInteracted = false;
	}
}