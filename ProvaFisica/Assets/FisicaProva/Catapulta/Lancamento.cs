using System.Collections;
using UnityEngine;

public class Lancamento : MonoBehaviour
{
    public HingeJoint hinge;
    public bool isLaunching = false;

    public float launchSpeed = 1000f;
    public float returnSpeed = 200f;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // Limites do movimento do braço da catapulta
        JointLimits limits = hinge.limits;
        limits.min = -60f;  // até onde o braço pode recuar
        limits.max = 0f;    // posição inicial
        hinge.limits = limits;
        hinge.useLimits = true;

        // Prepara o motor
        hinge.useMotor = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLaunching)
        {
            StartCoroutine(Lancar());
        }
    }

    IEnumerator Lancar()
    {
        isLaunching = true;

        // Etapa 1: Carregar (recuar)
        JointMotor motor = hinge.motor;
        motor.force = 100f;
        motor.targetVelocity = -returnSpeed; // recua lentamente
        hinge.motor = motor;

        yield return new WaitForSeconds(1.2f); // tempo de carregamento

        // Etapa 2: Lançar (avançar rápido)
        motor.targetVelocity = launchSpeed; // avança rápido
        hinge.motor = motor;

        yield return new WaitForSeconds(0.3f); // tempo de lançamento

        // Etapa 3: Parar o motor (deixa parado)
        motor.targetVelocity = 0f;
        hinge.motor = motor;

        isLaunching = false;
    }
}
