# Core Gameplay Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| CG001       | Movement           | Player can move in all four directions (WASD/Arrow keys).                                             | Player moves smoothly in all directions without stuttering.                                           | ✅         |
| CG002       | Movement           | Boss moves toward the player when within detection range.                                             | Boss moves smoothly toward the player until the player leaves the detection range.                   | ✅         |
| CG003       | Combat             | Player takes damage when in the boss's attack range.                                                  | Player's health decreases correctly and damage is applied only when attacked.                        | ✅         |
| CG004       | Combat             | Boss takes damage when attacked by the player.                                                        | Boss's health decreases correctly, and damage animation plays.                                        | ✅         |
| CG005       | Combat             | Boss attacks the player when in range.                                                                | Boss plays attack animation and damages the player when in range.                                     | ✅         |
| CG006       | Animations         | Player's walking animation plays correctly when moving.                                                | Walking animation plays in the correct direction based on input.                                      | ✅         |
| CG007       | Animations         | Boss's walking animation plays correctly when moving toward the player.                               | Walking animation plays until the boss stops moving or attacks.                                       | ✅         |
| CG008       | Animations         | Boss's idle animation plays correctly when not moving or attacking.                                   | Boss transitions to idle animation smoothly when not moving.                                          | ✅         |
| CG009       | Animations         | Boss attack animation loops only while actively attacking.                                            | Attack animation plays and returns to idle/moving after finishing.                                    | ✅         |
| CG010       | Animations         | Boss damage animation plays only when hit.                                                            | Damage animation plays briefly and transitions back to idle/moving.                                   | ✅         |
| CG011       | Animations         | Boss death animation plays when health reaches 0.                                                     | Death animation plays, and the boss object is destroyed after animation completes.                    | ✅         |

---

# Collision and Range Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| CR001       | Collision          | Player cannot pass through walls or other static objects.                                              | Player's movement is blocked by walls and static objects.                                             | ✅         |
| CR002       | Collision          | Boss cannot move through walls or other obstacles.                                                    | Boss pathfinding avoids obstacles and adjusts movement accordingly.                                   | ✅         |
| CR003       | Collision          | Player exits attack range, and boss stops attacking.                                                  | Boss stops the attack animation and damage application when the player leaves attack range.           | ✅         |
| CR004       | Range              | Boss detects player within detection range.                                                           | Boss begins moving toward the player when entering detection range.                                   | ✅         |
| CR005       | Range              | Boss does not detect the player outside detection range.                                               | Boss remains idle if the player is outside detection range.                                           | ✅         |

---

# Combat Balance Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| CB001       | Player Health      | Player health decreases accurately when hit by the boss.                                               | Player health decreases by the expected damage amount.                                                | ✅         |
| CB002       | Boss Health        | Boss health decreases accurately when hit by the player.                                               | Boss health decreases by the expected damage amount.                                                  | ✅         |
| CB003       | Boss Death         | Boss dies when health reaches 0.                                                                       | Boss plays death animation and is removed from the game.                                              | ✅         |
| CB004       | Player Death       | Player dies when health reaches 0.                                                                     | Game over screen appears, and player controls are disabled.                                           | ✅         |

---

# AI Behavior Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| AI001       | Pathfinding        | Boss moves around obstacles to reach the player.                                                      | Boss navigates efficiently around obstacles without getting stuck.                                    | ✅         |
| AI002       | Aggro Reset        | Boss returns to idle state if the player exits detection range for more than 3 seconds.               | Boss stops moving and returns to idle animation.                                                     | ✅         |
| AI003       | Aggro Range        | Boss re-engages if the player re-enters detection range after aggro reset.                            | Boss resumes movement toward the player.                                                             | ✅         |

---

# Performance and Stability Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| PS001       | Performance        | Game runs at 60 FPS on target hardware.                                                                | Frame rate remains consistent, with no significant drops.                                             | ✅         |
| PS002       | Stability          | Game does not crash when transitioning between scenes.                                                 | Scene transitions smoothly without errors or crashes.                                                 | ✅         |
| PS003       | Stability          | Boss behavior remains consistent even after multiple interactions.                                    | Boss AI, animations, and logic remain functional after repeated tests.                                | ✅         |

---

# User Interface Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| UI001       | Health Bar         | Player health bar updates correctly when taking damage.                                                | Health bar decreases in proportion to the damage taken.                                               | ✅         |
| UI002       | Health Bar         | Boss health bar updates correctly when taking damage.                                                  | Health bar decreases in proportion to the damage taken.                                               | ✅         |
| UI003       | Game Over Screen   | Game over screen appears when the player dies.                                                         | Game over screen is displayed, and all player controls are disabled.                                  | ✅         |
| UI004       | Victory Screen     | Victory screen appears when the boss dies.                                                             | Victory screen is displayed, and the player progresses to the next stage or level.                    | ✅         |

---

# Audio Tests

| **Test ID** | **Category**       | **Test Description**                                                                                   | **Expected Result**                                                                                   | **Status** |
|-------------|--------------------|-------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|------------|
| AU001       | Audio Effects      | Boss plays a sound when attacking.                                                                     | Attack sound effect plays during the attack animation.                                                | ✅         |
| AU002       | Audio Effects      | Boss plays a sound when hit.                                                                           | Hit sound effect plays during the damage animation.                                                   | ✅         |
| AU003       | Audio Effects      | Background music plays during gameplay.                                                               | Background music loops seamlessly throughout the game.                                                | ✅         |
# 

| **Category**          | **Test Description**                                                                                   | **Status**    |
|------------------------|-------------------------------------------------------------------------------------------------------|---------------|
| **Weapons**           | Verify all weapons deal damage as specified in their descriptions.                                    | ✅ |
| **Skills & Upgrades** | Ensure skills are unlockable only at designated points in progression.                                | ✅ |
|                        | Validate upgrades stack or remain mutually exclusive as intended.                                    | ✅ |
|                        | Test interactions between character-specific abilities and global skills.                            | ✅ |
| **Enemies**           | Verify each enemy type attacks, moves, and responds correctly.                                        | ✅ |
|                        | Test boss AI to ensure unique mechanics function properly.                                           | ✅ |
|                        | Ensure enemies drop correct loot or rewards upon defeat.                                             | ✅ |
| **Procedural Generation** | Test 100 procedurally generated levels to ensure no unreachable rooms or exits.                    | ✅ |
| **Environmental Interactions** | Validate destructible objects react properly to player and enemy attacks.                            | ✅ |
| **HUD**               | Verify HUD elements update dynamically (e.g., health, ammo).                                         | ✅ |
| **Inventory**         | Confirm players can pick up items without issues.                                                     | ✅ |
| **Frame Rate**        | Test FPS stability on low-end, mid-range, and high-end hardware.                                      | ✅ |
|                        | Run stress tests with maximum enemies and projectiles on screen.                                     | ✅ |
| **Loading Times**     | Measure loading times for each level and optimize for consistency.                                    | ✅ |


#

| **Category**          | **Test Description**                                                                                   | **Status**    |
|------------------------|-------------------------------------------------------------------------------------------------------|---------------|
| **Weapons**           | Test accuracy differences across weapon types (e.g., sniper rifle vs. submachine gun).                | ✅ Completed  |
| **Skills & Upgrades** | Test multiple skill stacking (e.g., movement speed upgrades).                                          | ✅ Completed  |
| **Enemies**           | Verify flying enemies (e.g., Wasp) path correctly around obstacles.                                    | ✅ Completed  |
|                        | Ensure turret enemies cannot attack outside their intended range or angle.                            | ✅ Completed  |
| **Procedural Generation** | Test placement of challenge rooms to ensure they are always reachable but optional.                 | ✅ Completed  |
|                        | Validate mini-boss and boss rooms spawn on the correct levels.                                        | ✅ Completed  |
|                        | Ensure shop rooms spawn at designated levels with correct inventory.                                  | ✅ Completed  |
| **Environmental Interactions** | Validate destructible environmental objects drop intended rewards (e.g., health potions).     | ✅ Completed  |
| **HUD**               | Verify energy/ammo bars deplete and refill correctly during gameplay.                                 | ✅ Completed  |
| **Inventory**         | Ensure inventory management works seamlessly when collecting multiple items quickly.                   | ✅ Completed  |
| **Loading Times**     | Ensure loading times are consistent across different hardware configurations.                          | ✅ Completed  |
|                        | Validate no crashes or freezes occur during level transitions.                                        | ✅ Completed  |
| **Visual Effects**    | Ensure special effects (e.g., explosions, plasma shots) display correctly and do not obstruct gameplay. | ✅ Completed  |
