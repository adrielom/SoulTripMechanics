using UnityEngine;
using System.Collections;

public class MaterialsManager {

    //Properties
    string name { get; set; }
    float weight { get; set; }
    float breakForce { get; set; }
    float spiningSpeed { get; set; }

    //Empty Constructor
    public MaterialsManager () {

    }

    //Constructor 2
    public MaterialsManager (string n, float w, float bF) {
        name = n;
        weight = w;
        breakForce = bF;
    }


    public MaterialsManager CombinationsMaterials (MaterialsManager m, MaterialsManager n) {

        MaterialsManager c = new MaterialsManager ();

        //New material's weight
        c.weight = CompareWeight (m.weight, n.weight);




        return c;

    }

    public float CompareWeight (float a, float b) {
        float c;

        if (a > b) {
            c = ((a + b) / 2) + a / 2;
        }
        else {
            c = ((a + b) / 2) +b / 2;
        }

        return c;
    }

    public float CompareWeight (float a, float b, float value) {
        float c;

        if (a > b) {
            c = ((a + b) / 2) + a / 2 + value;
        }
        else {
            c = ((a + b) / 2) + b / 2 + value;
        }

        return c;
    }
}
