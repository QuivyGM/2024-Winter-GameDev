# Flappy Clone V1 development log

Goal: create basic flappy bird with bird, pipe, scoreboard UI and end screen.

Clone Coding following [GMTK's Unity tutorisl](https://www.youtube.com/watch?v=XtQMytORBmM)

---

## 1. Understanding Unity Layout

![Layout_Image](Layout_Image.png)

1. **Project Window**: Contains all assets used in the game, both internal(Unity) and external.
   Examples: sprites, sound effects, scripts, tilemaps, fonts, etc.

2. **Hierarchy Window**: Lists all game objects present in the active scene/level.

   > **_Game Objects_**: Fundamental building blocks in Unity, which act as containers for components.
   > Each game object has properties such as position, rotation, and scale.
   > Examples of game objects: cameras, sprites, UI elements, and scenes.

3. **Inspector**: Displays and allows editing of the properties and components attached to the selected game object.
   Examples: add/modify components such as sprites, colliders, rigidbodies, custom scripts etc

4. **Scene**: Provides visual representation of the current scene or level.

## 2. Create Bird

![CreateBirdObject.png](CreateBirdObject.png)

1. Import/Create Bird and add it to **Project Window**.

2. Create **New Object** in **Hierarchy** and in **Inspector** add new component **Sprite Renderer**. Drag Bird Sprite from **Assets(Project Window)** and drag it to Sprite field(game object now references Bird Sprite in Assets).

![CreateBirdObject2.png](CreateBirdObject2.png){ width=500px }

3.  To Bird, add component **Rigidbody2D**

    - Rigidbody2D turns object into physics object with gravity

4.  To Bird, add component Collider- **Circle Collider 2D** and adjust collider to preference.

    - Collider allows object to interact with other objects

5.  To Bird, add new Script(ex: BirdScript) and double click to open VS.

    > ### Coding
    >
    > '''
    > using UnityEngine;
    >
    > public class BirdScript : MonoBehaviour
    > {
    > // Start is called once before the first execution of Update after the MonoBehaviour is created
    > void Start() {
    > }
    >
    > // Update is called once per frame
    > void Update() {
    >
    >      }
    >
    > }
    > '''
    > Other functions may be created to be called and executed in both existing or other scripts.
    > References may be needed to access and modify certain values/properties
