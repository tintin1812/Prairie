using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(NextTwineNodeInteraction))]
public class NextTwineNodeInspector : Editor
{
	NextTwineNodeInteraction nextTwineNode;
	public int index = 0;
	public TwineNode[] nodes;

	public override void OnInspectorGUI()
	{
		nextTwineNode = (NextTwineNodeInteraction)target;

		nodes = FindObjectsOfType(typeof(TwineNode)) as TwineNode[];

		List<GameObject> objectsWithTwineNode = new List<GameObject> ();
		List<string> twineNodeNames = new List<string> ();

		foreach (TwineNode node in nodes) {
			objectsWithTwineNode.Add (node.gameObject);
			twineNodeNames.Add (node.name);
		}

		// Display list of TwineNodes by their name
		string[] options = twineNodeNames.ToArray ();
		index = EditorGUILayout.Popup ("Next Twine Node Object", index, options);

		// Assign GameObject of selected TwineNode to nextTwineNodeObject
		nextTwineNode.nextTwineNodeObject = objectsWithTwineNode[index];
	}
}