using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Manager : MonoBehaviour {
	public InputField inputM1;
	public InputField inputM2;
	public InputField inputFR;
	public InputField inputVel;
	public Rigidbody cuerpo1;
	public Rigidbody cuerpo2;
	public Rigidbody cuerda1;
	public Rigidbody cuerda2;
	public SpringJoint resorte;
	public HingeJoint pendulo1;
	public HingeJoint pendulo2;
	public Text velM1;
	public Text velM2;
	private int masa1;
	private int masa2;
	private int fuerzaResorte;
	private int velocidadInicial;
	private Vector3 oscilarX = new Vector3 (0f, 0f, 1f);
	private Vector3 oscilarZ = new Vector3 (1f, 0f, 0f);

    // Start is called before the first frame update
    void Start() {
		masa1 = 1;
		masa2 = 1;
		fuerzaResorte = 10;
		velocidadInicial = 0;
    }

    // Update is called once per frame
    void Update() {
		// Muestra velocidad
		velM1.text = cuerpo1.velocity.magnitude.ToString("0.00");
		velM2.text = cuerpo2.velocity.magnitude.ToString("0.00");
		// Cambia los valores de masas y fuerza de resorte en tiempo de ejecucion
		cuerpo1.mass = masa1;
		cuerpo2.mass = masa2;
		resorte.spring = fuerzaResorte;
    }

	public void startSimulation() {
		// Obtengo valores
		if (!Int32.TryParse(inputM1.text, out masa1)) {
			masa1 = 1;
		}
		if (!Int32.TryParse(inputM2.text, out masa2)) {
			masa2 = 1;
		}
		if (!Int32.TryParse(inputFR.text, out fuerzaResorte)) {
			fuerzaResorte = 10;
		}
		if (!Int32.TryParse(inputVel.text, out velocidadInicial)) {
			velocidadInicial = 5;
		}

		// Actualizar la velocidad
		if (pendulo1.axis == oscilarX) {
			cuerpo1.velocity = new Vector3 (velocidadInicial, 0f, 0f);
		} else {
			cuerpo1.velocity = new Vector3 (0f, 0f, velocidadInicial);
		}
	}

	public void cambiarOscilacion() {
		// Le quito la velocidad
		// cuerpo1.velocity = new Vector3 (0f, 0f, 0f);
		// cuerpo2.velocity = new Vector3 (0f, 0f, 0f);
		// cuerda1.velocity = new Vector3 (0f, 0f, 0f);
		// cuerda2.velocity = new Vector3 (0f, 0f, 0f);
		// cuerpo1.angularVelocity = new Vector3 (0f, 0f, 0f);
		// cuerpo2.angularVelocity = new Vector3 (0f, 0f, 0f);
		// cuerda1.angularVelocity = new Vector3 (0f, 0f, 0f);
		// cuerda2.angularVelocity = new Vector3 (0f, 0f, 0f);

		// Posicion inicial de las masas y pendulos
		// cuerpo1.transform.position = new Vector3 (-1.5f, 0.5f, 0f);
		// cuerpo2.transform.position = new Vector3 (1.5f, 0.5f, 0f);
		// cuerda1.transform.position = new Vector3 (-1.5f, 1.5f, 0f);
		// cuerda2.transform.position = new Vector3 (1.5f, 1.5f, 0f);

		bool continuar = false;
		Vector3 cero = Vector3.zero;
		while (!continuar) {
			cuerpo1.velocity = Vector3.zero;
			cuerpo2.velocity = Vector3.zero;
			cuerda1.velocity = Vector3.zero;
			cuerda2.velocity = Vector3.zero;
			cuerpo1.angularVelocity = Vector3.zero;
			cuerpo2.angularVelocity = Vector3.zero;
			cuerda1.angularVelocity = Vector3.zero;
			cuerda2.angularVelocity = Vector3.zero;

			cuerpo1.Sleep();
			cuerpo2.Sleep();
			cuerda1.Sleep();
			cuerda2.Sleep();

			// Posicion inicial de las masas y pendulos
			cuerpo1.transform.position = new Vector3 (-1.5f, 0.5f, 0f);
			cuerpo2.transform.position = new Vector3 (1.5f, 0.5f, 0f);
			cuerda1.transform.position = new Vector3 (-1.5f, 1.5f, 0f);
			cuerda2.transform.position = new Vector3 (1.5f, 1.5f, 0f);

			pendulo1.connectedAnchor = new Vector3(-1.5f, 2.5f, 0f);
			pendulo2.connectedAnchor = new Vector3(1.5f, 2.5f, 0f);

			if (cuerpo1.velocity == cero && cuerpo2.velocity == cero) {
				continuar = true;
			}

		}

		Debug.Log("@HOLA");
		// Cambio de direccion de oscilacion
		if (pendulo1.axis == oscilarZ) {
			pendulo1.axis = oscilarX;
			pendulo2.axis = oscilarX;
		} else {
			pendulo2.axis = oscilarZ;
			pendulo1.axis = oscilarZ;
		}
	}

}
