using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(NextTwineNodeInteraction))]
public class NextTwineNodeInspector : Editor
{

	public override void OnInspectorGUI()
	{
		NextTwineNodeInteraction nextTwineNodeInteraction = (NextTwineNodeInteraction)target;
		TwineNode[] nodes = FindObjectsOfType(typeof(TwineNode)) as TwineNode[];

		nextTwineNodeInteraction.selectedTwineNodeIndices = PrairieGUI.drawTwineNodeDropdownList ("Associated Twine Nodes", "Twine Node Object",
																									nodes, nextTwineNodeInteraction.selectedTwineNodeIndices);

		nextTwineNodeInteraction.UpdateTwineNodeObjectsFromIndices (nodes);
	}
}