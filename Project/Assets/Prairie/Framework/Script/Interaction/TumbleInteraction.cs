﻿using UnityEngine;
using System.Collections;

public class TumbleInteraction : Interaction
{
	/// <summary>
	/// Allows user to rotate object.
	/// </summary>
	private bool pickedUp = false;
	private Prompt prompt;

	public static Mesh tumbleMesh;

	// When the user interacts with object, they invoke the ability to 
	// tumble the object with the I, J, K and L keys. Interacting
	// with the object again revokes this ability.

	void Start()
	{
		prompt = this.GetComponent<Prompt>();
		prompt.promptText = "Click to Pick Up";
	}

	void OnDrawGizmos() 
	{
		// Draw a yellow static mesh of the object's starting orientation
		Gizmos.color = Color.yellow;
		tumbleMesh = GetComponent<MeshFilter> ().sharedMesh;
		Gizmos.DrawWireMesh (tumbleMesh, transform.position);
	}

	protected void Update()
	{
		if (pickedUp)
		{

			if (Input.GetKey (KeyCode.L)) // right
			{
				transform.RotateRelativeToCamera (-10, 0);
			}
			else if (Input.GetKey (KeyCode.J)) // left
			{
				transform.RotateRelativeToCamera (10, 0);
			}
			else if (Input.GetKey (KeyCode.K)) // down
			{
				transform.RotateRelativeToCamera (0, 10);
			}
			else if (Input.GetKey (KeyCode.I)) // up
			{
				transform.RotateRelativeToCamera (0, -10);
			}
			else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Escape))
			{
				FirstPersonInteractor player = this.GetPlayer ();
				if (player != null) {
					player.SetCanMove (true);
					player.SetDrawsGUI (true);
				}
				pickedUp = false;
			}
		}
	}

	protected override void PerformAction() {
		pickedUp = !pickedUp;
		FirstPersonInteractor player = this.GetPlayer ();
		if (player != null) {
			if (pickedUp)
			{
				player.SetCanMove (false);
				prompt.promptText = "Use the I,J,K and L keys to rotate. Click to put down.";
			}
			else
			{
				player.SetCanMove (true);
				prompt.promptText = "Click to Pick Up";
			}
		}

	}
}
