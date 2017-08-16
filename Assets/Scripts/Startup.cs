using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Startup : MonoBehaviour {
	private void Start() {
		Debug.Log("start");
		TextAsset jsonText = Resources.Load<TextAsset>("testvr");

		Debug.Log(root);
	}

	/*
	 * Dictionary<string, string> elements;
	List<KeyValuePair<string, string>> relationships;
	
	void Start () {
		elements = new Dictionary<string, string>();
		relationships = new List<KeyValuePair<string, string>>();
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(Application.dataPath + "/Resources/testvr.xml");
		XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;
		foreach (XmlNode n in nodeList) {
			if (n.Name == "elements") {
				loadElements(n);
			} else if (n.Name == "relationships") {
				loadRelationships(n);
			}
		}
	}

	void loadElements(XmlNode n) {
		XmlNodeList childList = n.ChildNodes;
		foreach (XmlNode c in childList) {
			if (c.Name == "element") {
				Debug.Log("identifier: " + c.Attributes["identifier"].Value);
				foreach (XmlNode e in c) {
					if (e.Name == "label") {
						Debug.Log("LABEL: " + e.InnerText);
						elements.Add(c.Attributes["identifier"].Value, e.InnerText);
					}
				}
			}
		}
	}

	void loadRelationships(XmlNode n) {
		XmlNodeList childList = n.ChildNodes;
		foreach (XmlNode c in childList) {
			if (c.Name == "relationship") {
				Debug.Log("source: " + c.Attributes["source"].Value);
				Debug.Log("target: " + c.Attributes["target"].Value);
				foreach (XmlNode e in c) {
					if (e.Name == "label") {
						Debug.Log("LABEL: " + e.InnerText);
						relationships.Add(new KeyValuePair<string, string>(c.Attributes["source"].Value, c.Attributes["target"].Value));
					}
				}
			}
		}
	}*/

	void Update () {
		
	}
}

public class Block {
	public string identifier { get; set; }
	public string blockType { get; set; }
	public string label { get; set; }
	public string documentation { get; set; }
	public string fillColour { get; set; }
	public string lineColour { get; set; }
	public int x { get; set; }
	public int y { get; set; }
	public int z { get; set; }
	public int width { get; set; }
	public int height { get; set; }
	public int depth { get; set; }
}

public class Connection {
	public string identifier { get; set; }
	public string connectionType { get; set; }
	public string label { get; set; }
	public string sourceIdentifier { get; set; }
	public string targetIdentifier { get; set; }
	public string lineColour { get; set; }
}

public class RootObject {
	public List<Block> blocks { get; set; }
	public List<Connection> connections { get; set; }
}

public static class JsonHelper {
	public static T[] FromJson<T>(string json) {
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}

	public static string ToJson<T>(T[] array) {
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper);
	}

	public static string ToJson<T>(T[] array, bool prettyPrint) {
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}

	public static string fixJson(string value) {
		value = "{\"Items\":" + value + "}";
		return value;
	}

	private class Wrapper<T> {
		public T[] Items;
	}
}