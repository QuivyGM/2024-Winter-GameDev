# Flappy Clone V1 development log

Goal: create basic flappy bird with bird, pipe, scoreboard UI and end screen.

Clone Coding following [GMTK's Unity tutorisl](https://www.youtube.com/watch?v=XtQMytORBmM)

---

## 1. Understanding Unity Layout

![Layout_Image](Layout_Image.png)

1. **Project Window**: Contains all assets used in the game, both internal(Unity) and external.
   Examples: sprites, sound effects, scripts, tilemaps, fonts, etc.
2. **Hierarchy Window**: Lists all game objects present in the active scene/level.
   - **_Game Objects_**: Fundamental building blocks in Unity, which act as containers for components.
     Each game object has properties such as position, rotation, and scale.
     Examples of game objects: cameras, sprites, UI elements, and scenes.
3. **Inspector**: Displays and allows editing of the properties and components attached to the selected game object.
   Examples: add/modify components such as sprites, colliders, rigidbodies, custom scripts etc
4. **Scene**: Provides visual representation of the current scene or level.
