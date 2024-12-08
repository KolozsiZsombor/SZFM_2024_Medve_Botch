# Functional Specification

## 1. Current Situation

Currently, there are no games that fit all our needs. Existing games either lack the necessary features or are limited to platforms that don’t suit us. This results in constant switching between games, disrupting continuity and enjoyment. Multiplayer features are also limited, especially online co-op, which complicates playing together.

## 2. Dream Situation

We aim to create a game that consolidates all desired features, ensuring compatibility with our platform preferences. By developing this game, we can adapt and modify it to our needs over time. The absence of monetization ensures it remains free and accessible to anyone.

## 3. Game Overview

The game unfolds across three unique worlds, each containing 10 procedurally generated levels. These levels consist of interconnected rooms filled with enemies, shops, and optional challenge rooms. Players will progress by defeating enemies, purchasing upgrades, and tackling bosses at key milestones. Completing the game rewards players with a certificate detailing their accomplishments.

### 3.1 Gameplay Mechanics

The gameplay focuses on a "shoot-and-scoot" mechanic complemented by weapons, upgrades, and character abilities.

#### 3.1.1 Weapons

Weapons range from traditional firearms to futuristic plasma cannons, providing versatility and strategic options.

- **Standard Assault Rifle**: Balanced damage, accuracy, and fire rate.
- **Elemental Assault Rifle**: Higher damage, slower fire rate, and elemental effects.
- **Light Machine Gun**: High damage and fire rate, low accuracy, slows player.
- **Submachine Gun**: Low damage, high fire rate, increases movement speed.
- **Sniper Rifle**: One-shot kills standard enemies, slow fire rate, high accuracy.
- **Anti-Materiel Rifle**: Devastating damage, pierces multiple enemies, heavy recoil.
- **Assault Carbine**: Semi-automatic, higher accuracy, and damage than the standard rifle.
- **Designated Marksman Rifle**: Sniper rifle-lite with reduced damage but higher fire rate.
- **Grenade Launcher**: Area-of-effect explosions, good for groups of enemies.
- **Rocket Launcher**: Homing rockets with high damage and concussive effects.
- **Melee Weapons**: Ranges from knives to plasma swords, can deflect bullets.
- **Bow and Crossbow**: Long-range, high-damage weapons with distinct mechanics.
- **Laser Weapons**: Continuous beam, increasing damage over time, perfect accuracy.
- **Plasma Cannon**: Charged shot with high damage and piercing capability.

#### 3.1.2 Enemies

- **Dwarf**: Melee attacker with medium HP.
- **Wolf**: Low HP, fast, and lunges to attack.
- **Trapper**: Drops mines, medium HP, mines explode on one hit.
- **Turret**: Stationary, projectile attacks, high HP.
- **Wasp**: Flying, stings the player, low HP.

#### 3.1.3 Skills, Abilities, and Upgrades

- **Skills**: Acquired during gameplay, examples include elemental immunity, increased health, movement speed, or flight.
- **Abilities**: Character-specific and non-interchangeable.
- **Upgrades**: Applied to weapons, ranging from damage increases to elemental effects.

### 3.2 Different Maps and Terrain

Levels will feature diverse terrains like ice, grass, and sand, which impact movement and visibility.

### 3.3 Game World

The world resembles Earth, avoiding sci-fi aesthetics, focusing on familiar landscapes.

### 3.4 Target Audience

The game caters to all age groups, offering action and adventure elements that appeal broadly.

## 4. Main Requirements

### 4.1 User Interface (UI)

- **Main Menu**: Game title, New Game, Continue Game, Options, and Quit in a vertical layout.
- **In-game HUD**: Displays player HP, energy/ammo, and enemy HP. Boss HP appears prominently at the top of the screen.
- **Settings Menu**: Options for audio (music/effects), keyboard controls, and particle effects.

### 4.2 Characters

- **Playable Characters**: Characters with unique abilities and customizable appearances.
- **NPCs**: Includes the shopkeeper who sells items and weapons.

### 4.3 Game Mechanics

- **Combat System**: Ranged and melee combat with skill-based progression.
- **Inventory System**: Allows players to collect and manage items effectively.
- **Progression System**: Skill trees, weapon upgrades, and level-based rewards.

### 4.4 Missions/Quests

- **Main Quests**: Progression through worlds and defeating bosses.
- **Side Quests**: Optional challenges that provide additional rewards.

### 4.5 Audio and Visuals

- **Graphics**: Pixel art style with scalable resolution.
- **Sound Design**: Background music, dynamic sound effects, and minimal voice acting.

## 5. Other Requirements

### 5.1 Performance

The game must run smoothly on low-end hardware, maintaining at least 60 FPS.

### 5.2 Compatibility

The initial version will be for Windows, with potential future migration to mobile platforms.

### 5.3 Usability

Includes an interactive tutorial, accessibility options like colorblind modes, and intuitive controls.

### 5.4 Security

As a single-player game, security concerns are minimal.

## 6. Development and Implementation

### 6.1 Technology Stack

The game will be developed in Unity using C#. Graphic assets will be created using tools like Aseprite for pixel art.

### 6.2 Team Roles and Responsibilities

- **Project Manager**: Oversees development.
- **Developers**: Implement game mechanics and systems.
- **Designers**: Create levels, characters, and UI.
- **Testers**: Ensure quality and bug-free gameplay.

### 6.3 Timeline and Milestones

- **2024-10-14**: Project Start.
- **2024-11-30**: Initial gameplay prototype.
- **2025-01-15**: First playable build.
- **2025-03-01**: Beta release for testing.
- **2025-06-01**: Final release.

## 7. Testing and Quality Assurance

### 7.1 Testing Strategies

The game will undergo unit, integration, and user testing to ensure quality.

### 7.2 Bug Tracking

Bugs will be logged and tracked via a Kanban board.

### 7.3 Acceptance Criteria

Features will be marked as complete only after rigorous testing confirms their functionality.

## 8. Future Enhancements

### 8.1 Potential Features

- Expanded maps, additional worlds, and new characters.
- Enhanced AI for enemies.
- Online co-op gameplay.

### 8.2 Community Feedback

A testing phase will gather player feedback to refine gameplay before the final release.
