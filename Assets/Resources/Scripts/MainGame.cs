using UnityEngine;
using System.Collections;


public class MainGame : MonoBehaviour {

    public GameObject glassPrefab, woodPrefab, ironPrefab;

 	void Start () {

	}
	
	public void InstantiateMaterial (MaterialsManager m) {
        if (m.numbOfMaterials > 0) {
            m.numbOfMaterials--;
                if (m.name == "Glass")
                    Instantiate (glassPrefab);
                else if (m.name == "Wood")
                    Instantiate (woodPrefab);
                else if (m.name == "Iron")
                    Instantiate (ironPrefab);
        }
    }
}
