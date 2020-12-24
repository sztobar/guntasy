using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public static class EditorUtils {

  public static VisualElement CreateDefault(SerializedObject serializedObject) {
    var root = new VisualElement();
    // Loop through properties and create one field for each top level property.
    SerializedProperty property = serializedObject.GetIterator();
    property.NextVisible(true); // Expand the first child.
    do {
      // Create the UIElements PropertyField.
      PropertyField uieDefaultProperty = new PropertyField(property) {
        name = property.name
      };
      root.Add(uieDefaultProperty);
    } while (property.NextVisible(false));
    return root;
  }

  public static VisualElement CreateDefault(SerializedProperty property) {
    var root = new VisualElement();
    AddDefaultProperties(root, property);
    return root;
  }

  public static void AddDefaultProperties(VisualElement root, SerializedProperty property) {
    foreach (var prop in GetChildren(property)) {
      PropertyField uieDefaultProperty = new PropertyField(prop);
      uieDefaultProperty.name = prop.name;
      root.Add(uieDefaultProperty);
    }
  }

  // taken from thread: https://forum.unity.com/threads/loop-through-serializedproperty-children.435119/
  public static IEnumerable<SerializedProperty> GetChildren(SerializedProperty property) {
    property = property.Copy();
    var nextElement = property.Copy();
    bool hasNextElement = nextElement.NextVisible(false);
    if (!hasNextElement) {
      nextElement = null;
    }

    property.NextVisible(true);
    while (true) {
      if (SerializedProperty.EqualContents(property, nextElement)) {
        yield break;
      }

      yield return property;

      bool hasNext = property.NextVisible(false);
      if (!hasNext) {
        break;
      }
    }
  }
}
