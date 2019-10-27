using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParticle : MonoBehaviour
{
    public bool overrideAxisOfRotation;
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (overrideAxisOfRotation)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particles);

            for (int i = 0; i < particles.Length; i++)
                particles[i].axisOfRotation = Vector3.up;

            ps.SetParticles(particles, ps.particleCount);
        }
    }

    private void OnGUI()
    {
        bool newValue = GUI.Toggle(new Rect(10, 10, 200, 30), overrideAxisOfRotation, new GUIContent("Override Axis of Rotation"));
        if (newValue != overrideAxisOfRotation)
        {
            ps.Clear();
            overrideAxisOfRotation = newValue;
        }
    }
}
