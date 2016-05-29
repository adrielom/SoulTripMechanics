using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MaterialEnum {glass, iron, wood };

public class IndividualMaterial : MonoBehaviour {


    //TO CREATE A NEW MATERIAL OBJECT. CREATE THE OBJECT, CREATE A NEW ENUM MATERIAL AND A NEW CASE ON THE SWITCH
    [SerializeField]
    public MaterialEnum thisMaterial;
    public float thisBreakForce;

    //Creating the objects
    List<MaterialsManager> allMaterials = new List<MaterialsManager> ();

    MaterialsManager glass = new MaterialsManager ("Glass", 1, 1, 100, 50);
    MaterialsManager iron = new MaterialsManager ("Iron", 100, 100, 20, 10);
    MaterialsManager wood = new MaterialsManager ("Wood", 40, 40, 30, 25);

    public float offSet = 0.57f, distance = 10f;

     void Start () {

        allMaterials.Add (glass);
        allMaterials.Add (iron);
        allMaterials.Add (wood);

        switch (thisMaterial) {
            case MaterialEnum.glass:
                SettingMaterialsInstances (glass);
            break;

            case MaterialEnum.iron:
                SettingMaterialsInstances (iron);
            break;

            case MaterialEnum.wood:
                SettingMaterialsInstances (wood);
            break;
        }
	}

    public void SettingMaterialsInstances (MaterialsManager m) {
        this.gameObject.name = m.name;
        thisBreakForce = m.breakForce;
        this.gameObject.GetComponent<Rigidbody2D> ().mass = m.weight;
        this.gameObject.GetComponent<Rigidbody2D> ().angularVelocity = m.spiningSpeed;
    }

    void LateUpdate () {

        //REMENBER TO FIX THE RAYCASTING DRAGS. YOU'VE GOT TO SET THE DRAG TO THE OBJECT'S DRAGFORCE ONLY WHEN THE OBJECTS' GROUNDED
        Raycasting (offSet, distance);
    }

   
    public void Raycasting (float offSet, float distance) {
        Vector2 down = new Vector2 (transform.position.x, transform.position.y - offSet);
        RaycastHit2D downHit = Physics2D.Raycast (down, Vector2.down/distance, distance );
        Debug.DrawRay (down, Vector2.down/distance);
        if (downHit.collider != null && downHit.collider.name != "Floor") {
            if (CheckNameCollision (downHit) < thisBreakForce)
                Destroy (downHit.collider.gameObject); 
        }
    }
   
   public float CheckNameCollision (RaycastHit2D r) {

        float force = 0;
        foreach (MaterialsManager m in allMaterials) {
            if (r.collider.name == m.name) 
                force = m.breakForce;
        }

        return force;
    }
}
