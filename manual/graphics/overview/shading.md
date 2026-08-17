# Shading

Flax implements Physically-Based Rendering with BRDF shading that tries to realistically simulate how light reacts with object surfaces and bounces off.

## Standard Shading

Material diffuse and specular colors are computed based on material properties as follows:

```
diffuseColor = materialColor * (1 - materialMetalness)
dielectricF0 = 0.16 * materialSpecular^2;
specularColor = lerp(dielectricF0, color, materialMetalness)
```

Default shading formula calculates lighting as follows:

```
diffuseLight = Diffuse_Lambert(diffuseColor);
F = F_Schlick(specularColor, VoH);
D = D_GGX(roughnessSq, NoH) * energy;
Vis = V_SmithJointApprox(roughnessSq, NoV, NoL);
specularLight = (D * Vis) * F;
```

## GBuffer

GBuffer is a set of render target images used to capture common material properties such as color, metalness, roughness, and surface normals to calculate per-pixel lighting as a deferred lighting pass. This technique is commonly used in rendering as it decouples shading/shadowing complexity from materials rendering stage.

GBuffer layout:

```
* GBuffer0: [RGB] Color, [A] AO
* GBuffer1: [RGB] Normal, [A] ShadingModel
* GBuffer2: [R] Roughness, [G] Metalness, [B] Specular, [A] UNUSED
* GBuffer3: [RGBA] Custom Data (per shading mode)
```
