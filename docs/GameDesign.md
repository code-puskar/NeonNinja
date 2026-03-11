# Game Design Document: Neon Ninja

## Game Concept
A fast-paced, 2D side-scrolling auto-runner where the player uses quick swipe gestures to navigate obstacles and dispatch enemies in a vibrant, neon cyber-ninja setting.

## Core Gameplay Loop
1.  **Run:** The ninja constantly moves forward at an increasing speed.
2.  **React:** Obstacles and enemies appear on the screen.
3.  **Swipe/Slash:** The player swipes the screen to perform actions:
    *   **Swipe Up:** Jump/Upward Slash (to clear low obstacles or hit aerial enemies).
    *   **Swipe Down:** Slide/Downward Strike (to go under high obstacles or hit low enemies).
    *   **Swipe Forward (Right):** Dash/Forward Slash (to quickly close distance or break through barriers).
4.  **Survive & Score:** Chain combos and survive as long as possible to achieve a high score.

## Visual Style
*   Dark backgrounds with bright, high-contrast neon accents (cyan, magenta, lime green).
*   Smooth, stylized 2D sprite animations for the ninja and enemies.
*   Particle effects for slashes and dashing.

## Technical Considerations (Unity 2D)
*   **Input Handling:** Implementing a robust swipe detection system that quickly registers direction and magnitude.
*   **Object Pooling:** Essential for managing the continuous spawning of enemies, obstacles, and background elements to maintain high performance.
*   **Physics/Movement:** The player character needs precise, responsive movement parameters (jump height, dash distance, slide duration).
*   **Camera:** A fixed camera that follows the player along the X-axis, potentially with slight screen shake on impactful hits or dashes.
