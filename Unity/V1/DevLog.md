# Flappy Clone V1 development log

Goal: create basic flappy bird with bird, pipe, scoreboard UI and end screen.

Clone Coding following [GMTK's Unity tutorisl](https://www.youtube.com/watch?v=XtQMytORBmM)

---

## 1. Understanding Unity Layout

<div align="center">
  <img src="Dev Log Image\Layout_Image.png" alt="Layout Image" width="750">
</div>

1. **Project Window**: Contains all assets used in the game, both internal(Unity) and external.
   Examples: sprites, sound effects, scripts, tilemaps, fonts, etc.

2. **Hierarchy Window**: Lists all game objects present in the active scene/level.

   > **_Game Objects_**: Fundamental building blocks in Unity, which act as containers for components.
   > Each game object has properties such as position, rotation, and scale.
   > Examples of game objects: cameras, sprites, UI elements, and scenes.

3. **Inspector**: Displays and allows editing of the properties and components attached to the selected game object.
   Examples: add/modify components such as sprites, colliders, rigidbodies, custom scripts etc

4. **Scene**: Provides visual representation of the current scene or level.

---

## 2. Create Bird

<div align="center">
  <img src="Dev Log Image\CreateBirdObject.png" alt="Create Bird Object" width="750">
</div>

**1. Import/Create Bird and add it to ***Project Window***.**

**2. Create ***New Object*** in ***Hierarchy*** and in ***Inspector*** add new component ***Sprite Renderer***.**
  - Drag Bird Sprite from **Assets(Project Window)** and drag it to Sprite field(game object now references Bird Sprite in Assets).

<div align="center">
  <img src="Dev Log Image\CreateBirdObject2.png" alt="Create Bird Object" width="750">
</div>

**3.  To Bird, add component ***Rigidbody2D***.**
    -> now when run the Bird will fall downwards and out of frame.
  > [Rigidbody](https://docs.unity3d.com/Manual/rigidbody-physics-section.html): enable physics-based behaviour such as movement, gravity, and collision.

  - Rigidbody2D: turns object into physics object with gravity

**4.  To Bird, add component Collider- ***Circle Collider 2D*** and adjust collider to preference.**

  > [Collider](https://docs.unity3d.com/Manual/2d-physics/collider/collider-2d-landing.html): enabling interactions and handling physical behavior in games, especially when combined with Rigidbody components.

**5.  To Bird, add new Script(ex: BirdScript) and double click to open VS.**

  > ### Coding
  >
  > ```csharp
  > using UnityEngine;
  >
  > public class BirdScript : MonoBehaviour
  > {
  >     // Start is called once before the first execution of Update after the MonoBehaviour is created
  >     void Start() {
  >     }
  >
  >     // Update is called once per frame
  >     void Update() {
  >     }
  > }
  > ```
  >
  > Other functions may be created to be called and executed in both existing or other scripts.  
  > References may be needed to access and modify certain values/properties.

**6. Add upward velocity when [space] is pressed.**
   
  1. **Initially script can only 'talk' to game object's top bit(name, tag, layer etc) and the Transform component -> need to create reference.**

       ```csharp
    
       public class BirdScript : MonoBehaviour
       {
       //references that can be /modifaccessedied from unity
       public Rigidbody2D myRigidbody; // gives script access to values in Rigidbody2d
    
       void Start() {
       ```
     -> Script component now has field for Ridibody 2D. Dragging Rigidbody 2D component will assign reference.

  2. Assign velocity when space is pressed.

     - Keyboard Input: Input.GetKeyDown(KeyCode._key name here_)
     - change velocity: myRigidbody (reference name from 6-1) . linearVelocity (vector for velocity direction) = _vector value_ (Vector2._direction_ is shorthand for vector direction - ex: Vector2.up == (0,1))
     - allow ease of testing and value changes create _public float flapStrength_ to change values in Unity Window
        <div align="center">
           <img src="Dev Log Image\flapStrenghField.png" alt="flapStrenghField.png" width="500">
        </div>
    
       ```csharp
       public float flapStrength; // preferably place above void Start()
      
       void Update() {
       if (Input.GetKeyDown(KeyCode.Space) == true) //Input.GetKeyDown(KeyCode.Space)
         {
         myRigidbody.linearVelocity = Vector2.up * flapStrength;
           //Vector2.up == (0,1) -> changes velocity to move towards (0,1) of current position (times flapStrength)
         }
       }
       ```
       
**7. Create Prefab for Pipes**
  > **[Prefab](https://docs.unity3d.com/Manual/Prefabs.html)**(Prefabricated Gameobjct): basically a blueprint for gameobjcts that can be resued
  1. Create new Gameobject("Pipes") and add child object *Top_Pipe*. Adjust position, size, rotation values as needed.
  2. Add BoxCollider2D component. (Rigidbody is not needed as it isn't affected by physics)
  3. Create code for pipe movement.
      ```csharp
       using UnityEngine;
      
      public class pipeMoveScript : MonoBehaviour
      {
        public float moveSpeed = 1f;
        public float deadZone = -11f;
      
        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
      
            if (transform.position.x < deadZone) {
                Debug.Log("Pipe Deleted");
                Destroy(gameObject);
            }
        }
      }
      ```
      - public floats for movementSpeed(speed of which the pipes move) and deadzone(area where pipes despawn)
      - change transform.position values to move left by value of Vector3.left (-1, 0) multiplied by moveSpeed.
        - movement value is multiplied by deltaTime to avoid issue of movement being tied to framerate (void Update is run every frame -> movement happens every frame
      > [deltaTime](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html): interval in seconds from the last frame to the current one
      -if statement to [destroy](https://docs.unity3d.com/ScriptReference/Object.Destroy.html) objecty if passing deadzone + [debug.log](https://docs.unity3d.com/ScriptReference/Debug.Log.html) to check destruction
  4. Copy-Paste *Top_Pipe* and add it as another child object of "Pipes". Adjust position, rotation, scale as needed.
  <div align="center">
    <img src="https://github.com/user-attachments/assets/3e3d2eff-6a0e-4768-83fe-1e3757096996" width="500" />
  </div>
  
  6. Drag gameObject from Hierarchy to Project Window to finalize Prefab creation. (You can delete Pipe from hierarchy afterwards)

**8. Create Pipe Spawner**
  1. Create new Gameobject("PipeSpawner") and adjuts position values as needed.
  2. Create script component and create reference for game object and(in Unity) drag Pipe prefab into reference field.
  3. In *void Update()* use Instantiate() to write code for spawning pipes.
    > Instantiate: create a new copy of an object, like spawning a new enemy or item in the game.
    >                   Instantiate(myPrefab, position, rotation);
  5. Create timer to space out spawning of Pipes.
  <div align="center">
     <img src="https://github.com/user-attachments/assets/d279acb1-d656-437b-aa64-2403f39c94d4" width="500" />
  </div>

  - pipe spawn is made as function 'spawnPipe' to ease repetitive use

  6. **To spawn pipes at differing heights** create public float heightoffset and within spawnPipe create float lowestPoint and highestPoint using heighoffset. (allows adjustment in Unity screen)
  7. Change position value in Instantiate to *new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint))*. Pipes will now spawn in random height within set range.


