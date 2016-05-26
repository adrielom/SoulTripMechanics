using UnityEngine;
using System.Collections;

public enum MaterialEnum {glass, iron, wood };

public class IndividualMaterial : MonoBehaviour {

    [SerializeField]
    public MaterialEnum thisMaterial;

	void Start () {
	    switch (thisMaterial) {
            case MaterialEnum.glass:
                MaterialsManager glass = new MaterialsManager ("Glass", 1, 1, 100, 50, 1);
                this.gameObject.name = glass.name;
                this.gameObject.GetComponent<Rigidbody2D> ().mass = glass.weight;
                this.gameObject.GetComponent<Rigidbody2D> ().angularVelocity = glass.spiningSpeed;
                this.gameObject.GetComponent<Rigidbody2D> ().drag = glass.dragForce;
            break;

            case MaterialEnum.iron:
                MaterialsManager iron = new MaterialsManager ("Iron", 100, 100, 20, 10, 20);
                this.gameObject.name = iron.name;
                this.gameObject.GetComponent<Rigidbody2D> ().mass = iron.weight;
                this.gameObject.GetComponent<Rigidbody2D> ().angularVelocity = iron.spiningSpeed;
                this.gameObject.GetComponent<Rigidbody2D> ().drag = iron.dragForce;
            break;

            case MaterialEnum.wood:
               MaterialsManager wood = new MaterialsManager ("Wood", 40, 40, 30, 25, 10);
               this.gameObject.name = wood.name;
               this.gameObject.GetComponent<Rigidbody2D> ().mass = wood.weight;
               this.gameObject.GetComponent<Rigidbody2D> ().angularVelocity = wood.spiningSpeed;
               this.gameObject.GetComponent<Rigidbody2D> ().drag = wood.dragForce;
            break;
        }
	}


    void FixedUpdate () {

        //REMENBER TO FIX THE RAYCASTING DRAGS. YOU'VE GOT TO SET THE DRAG TO THE OBJECT'S DRAGFORCE ONLY WHEN THE OBJECTS' GROUNDED
        Raycasting ();
    }

    public void Raycasting () {
        RaycastHit2D downHit = Physics2D.Raycast (transform.position, Vector2.down, 1);
        Debug.DrawRay (transform.position, Vector2.down);
        RaycastHit2D upHit = Physics2D.Raycast (transform.position, Vector2.up, 1);
        Debug.DrawRay (transform.position, Vector2.up);
        RaycastHit2D leftHit = Physics2D.Raycast (transform.position, Vector2.left, 1);
        Debug.DrawRay (transform.position, Vector2.left);
        RaycastHit2D rightHit = Physics2D.Raycast (transform.position, Vector2.up, 1);
        Debug.DrawRay (transform.position, Vector2.right);
    }

}
