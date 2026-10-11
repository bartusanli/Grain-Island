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

In **Grain Island**, you are not stranded on static bedrock. The island beneath your feet is the shell of an ancient, breathing sea titan. Every tree felled and mineral vein extracted disturbs the slumbering creature, shifting coastal tides and triggering metabolic reactions.

Instead of passive waiting cycles, *Grain Island* introduces an active risk-reward loop: pushing the creature's unrest to its upper limit yields rapid resource respawns and exposes rare mineral nodes. However, crossing the threshold unleashes devastating seismic tremors. Survival demands that you become not just an extractor, but a devoted caretaker.

---

## 🎮 Core Gameplay Mechanics

### 1. The Slumbering Behemoth & Restlessness Gauge
* **Living Surface:** The island's geography dynamically shifts based on the leviathan's agitation level.
* **Push-Your-Luck Progression:** Harvesting lumber and mining minerals directly fills the **Restlessness Bar**.
* **High-Risk High-Reward:** As unrest reaches 80–90%, coastal waters recede and rare sapphire/gold mineral nodes regenerate at accelerated rates.

### 2. Active Pacification (No Passive Decay)
* **Symbiotic Agriculture:** The creature cannot be calmed by waiting idly.
* **Healing Acts:** Tilling soil, planting saplings, and watering seedlings actively soothe the leviathan, lowering the unrest gauge.
* **Strategic Tension:** When unrest approaches critical levels (90%+), players must transition instantly from aggressive mining to frantic agricultural restoration.

### 3. The "Slam" Phase & Dynamic Crisis Management
* **The Threshold (100% Unrest):** If the gauge caps, the leviathan slams its dorsal shell against the ocean surface.
* **Consequences:**
  * Workstations, fences, and storage chests suffer physical structural damage, requiring emergency repairs.
  * Quality crops drop a grade (Sapphire → Gold → Silver → Standard).
* **Emergency Rebound:** Players spend the aftermath stabilizing food supplies, repairing facilities, and recovering from their own greed without facing an abrupt Game Over screen.

---

## 🎨 Art Style & Visual Direction

* **Stylized 3D / Low-Poly:** Inspired by the colorful, expressive, and readable visual design of *Overcooked!*, presented from an isometric 2.5D camera angle.
* **Juice & Game Feel:** Squash-and-stretch object feedback, dynamic camera shakes via DOTween, procedural water shaders with foamy tidelines, and impact particle effects.
* **Atmospheric Contrast:** Calming pastel tones during balance, contrasting sharply with turbulent ocean swells and ground tremors when unrest peaks.

---

## 🛠️ Tech Stack & Architecture

* **Engine:** Unity (Universal Render Pipeline - URP)
* **Language:** C# (.NET)
* **Architecture:**
  * **Event-Driven Messaging:** Decoupled event buses connecting resource extraction, farming, and UI directly to the central `RestlessnessManager`.
  * **Grid-Based Interaction:** Spatial partitioning for clean tilling, crop lifecycle tracking, and structure placement snapping.
  * **Input System:** Unity New Input System supporting seamless switching between Keyboard/Mouse and Gamepad.
* **External Tools & Packages:**
  * **DOTween (Demigiant):** Procedural UI animations, bouncy feedback, and screen shakes.
  * **Blender:** 3D low-poly modeling, UV unwrap, and lightweight character rigging.

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
Open Unity Hub and select Add project from disk.

Select the root folder of the cloned repository.

Launch the project using Unity 2022.3 LTS and open:

Plaintext
Assets/Scenes/MainIsland.unity
Enter Play Mode to run the prototype.

👤 Author
Bartu Şanlı - Solo Developer (Game Design & Programming)

GitHub: [@bartusanli](https://github.com/bartusanli)

Project: [Grain Island](https://github.com/bartusanli/Grain-Island)

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.
