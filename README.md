# 🌾 Grain Island

[![Unity](https://img.shields.io/badge/Unity-2022.3%20LTS-black?style=for-the-badge&logo=unity)](https://unity.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP-informational?style=for-the-badge)](https://unity.com/srp/universal-render-pipeline)
[![Genre](https://img.shields.io/badge/Genre-Survival%20%7C%20Farming%20Sim-orange?style=for-the-badge)]()
[![Status](https://img.shields.io/badge/Development-Prototype%20%2F%20In%20Progress-brightgreen?style=for-the-badge)]()

> **A stylized low-poly survival and farming simulation set atop a slumbering ancient leviathan.**  
> Balance reckless resource exploitation against symbiotic ecosystem restoration in a high-tension "push-your-luck" loop.

---

## 🌊 Overview

In **Grain Island**, you are not stranded on static bedrock. The island beneath your feet is the shell of an ancient, breathing sea titan. Every tree felled and ore extracted disturbs the slumbering creature, shifting tides and triggering immediate geological reactions.

Instead of passive waiting cycles, *Grain Island* introduces a dynamic risk-reward dynamic: pushing the creature's unrest to its limit yields rapid resource respawns and exposes rare mineral veins. However, crossing the threshold unleashes devastating seismic tremors. Survival demands that you become not just an extractor, but a devoted caretaker.

---

## 🎮 Core Gameplay Mechanics

### 1. The Slumbering Behemoth & Restlessness Gauge
* **Living Surface:** The island's geography shifts based on the leviathan's metabolic state.
* **Push-Your-Luck Progression:** Harvesting wood and mining minerals directly fills the **Restlessness Bar**.
* **High-Risk High-Reward:** As unrest reaches 80–90%, coastal waters recede faster and rare sapphire/gold mineral nodes regenerate at accelerated rates.

### 2. Active Pacification (No Passive Decay)
* **Symbiotic Agriculture:** The creature cannot be calmed by waiting idly.
* **Healing Acts:** Tilling soil, planting saplings, and watering seedlings actively soothe the leviathan, lowering the unrest gauge.
* **Strategic Tension:** When unrest approaches 95%, players must immediately transition from greedy mining to frantic agricultural restoration.

### 3. The "Slam" Phase & Dynamic Crisis Management
* **The Threshold (100% Unrest):** If the gauge caps, the leviathan slams its dorsal shell against the ocean surface.
* **Non-Lethal, High-Stakes Consequence:**
  * Structures and workstations suffer physical damage, requiring immediate repairs.
  * Quality crops drop a rank (e.g., Sapphire $\rightarrow$ Gold $\rightarrow$ Silver $\rightarrow$ Copper).
* **Emergency Rebound:** Players spend the aftermath triaging repairs, stabilizing food supplies, and recovering from their own greed.

---

## 🎨 Art Style & Visual Direction

* **Stylized 3D / Low-Poly:** Inspired by the charming, colorful, and vibrant aesthetic of games like *Overcooked!*, combined with an isometric 2.5D camera view.
* **Dynamic Feedback & "Juice":** Exaggerated squash-and-stretch object physics, screen shakes driven by DOTween, procedural water shaders with foamy tidelines, and crisp particle VFX on impacts.
* **Atmospheric Contrast:** Warm, pastel tranquility during balance; shifting to turbulent, high-contrast ocean swells and ground tremors when unrest peaks.

---

## 🛠️ Tech Stack & Architecture

* **Engine:** Unity (Universal Render Pipeline - URP)
* **Language:** C# (.NET)
* **Architecture:**
  * **Event-Driven Architecture:** Decoupled event messaging (`Action<T>` / ScriptableObject GameEvents) connecting world actions to the Restlessness Manager.
  * **Grid-Based Placement:** Spatial partitioning for clean farming, crop stages, and building snapping.
  * **Input System:** Unity New Input System (Gamepad & Keyboard/Mouse support).
* **Tooling & Packages:**
  * **DOTween:** Procedural UI animations, camera shakes, and prop bounces.
  * **Blender:** Low-poly 3D modeling and lightweight character rigging.

---

## 📋 Controls

| Action | Keyboard & Mouse | Gamepad |
|---|---|---|
| **Move** | `W` `A` `S` `D` | Left Stick |
| **Interact / Pick Up** | `E` / Left Click | `A` (Xbox) / `Cross` (PS) |
| **Use Tool (Axe / Pickaxe / Hoe)** | Space / Left Click | `X` (Xbox) / `Square` (PS) |
| **Plant Seed / Water** | Right Click / `F` | `B` (Xbox) / `Circle` (PS) |
| **Inventory / Crafting** | `Tab` / `I` | `Y` (Xbox) / `Triangle` (PS) |

---

## 🚀 Getting Started

### Prerequisites
* Unity Hub
* Unity Editor `2022.3.x LTS` or newer
* Git LFS (Large File Storage)

### Installation
1. Clone the repository:
   ```bash
   git clone [https://github.com/](https://github.com/)<your-username>/grain-island.git
