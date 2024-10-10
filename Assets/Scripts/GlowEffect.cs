using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Color emissionColor; // The color of the glow
    float minEmission = 0f;          // Minimum glow intensity
    float maxEmission = 0.07f;          // Maximum glow intensity
    float glowSpeed = 0.1f;            // Speed of the glow pulse

    private Renderer objectRenderer;
    private Material[] objectMaterials;
    private float emissionStrength;

    void Start()
    {
        // Get the renderer and material of the object
        objectRenderer = GetComponent<Renderer>();


        // Get all materials used by the renderer
        objectMaterials = objectRenderer.materials;
    }

    void Update()
    {
        // Calculate emission strength using a sine wave for a pulsing effect
        emissionStrength = minEmission + Mathf.PingPong(Time.time * glowSpeed, maxEmission - minEmission);

        // Set the emission color with the calculated strength
        Color finalColor = emissionColor * Mathf.LinearToGammaSpace(emissionStrength);


        // Print the names of all materials to the console
        foreach (Material mat in objectMaterials)
        {
            // Apply the emission color to the material
            mat.SetColor("_EmissionColor", finalColor);
        }

    }
}
