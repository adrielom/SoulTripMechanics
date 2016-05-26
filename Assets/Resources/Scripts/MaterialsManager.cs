using UnityEngine;
using System.Collections;

public class MaterialsManager {

    //Properties
    public int numbOfMaterials { get; set; }
    public string name { get; set; }
    public float weight { get; set; }
    public float breakForce { get; set; }
    public float spiningSpeed { get; set; }
    public float dragForce { get; set; }

    //Empty Constructor
    public MaterialsManager () {

    }

    //Constructor 2
    public MaterialsManager (string n, float w, float bF) {
        name = n;
        weight = w;
        breakForce = bF;
    }

    //Constructor 3
    public MaterialsManager (int nM) {
        numbOfMaterials = nM;
    }

    //Constructor 4
    public MaterialsManager (string n, float w, float bF, float sS, int nM, float dF) {
        name = n;
        weight = w;
        breakForce = bF;
        spiningSpeed = sS;
        numbOfMaterials = nM;
        dragForce = dF;
    }

    public MaterialsManager CombinationsMaterials (MaterialsManager m, MaterialsManager n) {

        MaterialsManager c = new MaterialsManager ();

        //New material's weight
        c.weight = CompareWeight (m.weight, n.weight);

        //New material's breakForce
        c.breakForce = CompareBreakForce (m.breakForce, n.breakForce);

        return c;

    }

    //CompareWeight
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

    //CompareWeight + parameter
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

    public float CompareBreakForce (float a, float b) {
        float c;

        if (a > b) {
            c = ((a + b) / 2) * a / 2;
        }
        else {
            c = ((a + b) / 2) * b / 2;
        }

        return c;
    }

    //CompareWeight + parameter
    public float CompareBreakForce (float a, float b, float value) {
        float c;

        if (a > b) {
            c = ((a + b) / 2) * a / 2 + value;
        }
        else {
            c = ((a + b) / 2) * b / 2 + value;
        }

        return c;
    }
}
