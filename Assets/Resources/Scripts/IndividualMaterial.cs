using UnityEngine;
using System.Collections;

public enum MaterialEnum {glass, iron, wood };

public class IndividualMaterial : MonoBehaviour {

    [SerializeField]
    public MaterialEnum thisMaterial;

	void Start () {
	    switch (thisMaterial) {
            case MaterialEnum.glass:
                MaterialsManager glass = new MaterialsManager ("Glass", 1, 1, 100, 50);
                this.gameObject.name = glass.name;
                this.gameObject.GetComponent<Rigidbody2D> ().mass = glass.weight;
            break;

            case MaterialEnum.iron:
                MaterialsManager iron = new MaterialsManager ("Iron", 100, 100, 20, 10);
                this.gameObject.name = iron.name;
                this.gameObject.GetComponent<Rigidbody2D> ().mass = iron.weight;

            break;

            case MaterialEnum.wood:
               MaterialsManager wood = new MaterialsManager ("Wood", 40, 40, 30, 25);
               this.gameObject.name = wood.name;
               this.gameObject.GetComponent<Rigidbody2D> ().mass = wood.weight;

            break;
        }
	}

}
