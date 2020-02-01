using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairMenu : MonoBehaviour {

    public Camera Camera;
    public float RepairDistance;
    public LayerMask RepairableLayer;

    public Canvas RepairMenuCanvas;
    public Image RepairSlider;
    public Text RepairTitle;

    void Start() {
        
    }

    void Update() {
        var ray = new Ray(Camera.transform.position, Camera.transform.forward);
        RaycastHit hit;
        RepairMenuCanvas.enabled = false;
        if ( Physics.Raycast(ray, out hit, RepairDistance, RepairableLayer)) {
            var d = hit.collider.GetComponentInParent<Destroyable>();
            if (d && !d.IsAlive) {
                RepairMenuCanvas.enabled = true;
                RepairSlider.fillAmount = d.RepairAmount;
                RepairTitle.text = "Destroyed " + d.Name;

                if (Input.GetButton("Fire1"))
                    d.Repair(Time.deltaTime);
            }
        }
    }
}
