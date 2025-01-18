# Flappy Clone V1 development log

Goal: create basic flappy bird with bird, pipe, logic, UI and end screen.

Clone Coding following [GMTK's Unity tutorisl](https://www.youtube.com/watch?v=XtQMytORBmM)

---

## 1. Understanding Unity Layout

<div align="center">
  <img src="https://github.com/user-attachments/assets/cb148e29-2498-4e2d-84f9-9331664ee5e7" alt="Layout Image" width="750">
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
  <img src="https://github.com/user-attachments/assets/8c37c042-fcdf-4c08-b267-f864140f14d3" alt="Create Bird Object1" width="750">
</div>

**1. Import/Create Bird and add it to ***Project Window***.**

**2. Create ***New Object*** in ***Hierarchy*** and in ***Inspector*** add new component ***Sprite Renderer***.**
  - Drag Bird Sprite from **Assets(Project Window)** and drag it to Sprite field(game object now references Bird Sprite in Assets).

<div align="center">
  <img src="https://github.com/user-attachments/assets/bdc81af3-a4a4-4e32-8f1a-2fb04c1433f0" alt="Create Bird Object" width="750">
</div>

**3.  To Bird, add component ***Rigidbody2D***.**
    -> now when run the Bird will fall downwards and out of frame.
  > [Rigidbody](https://docs.unity3d.com/Manual/rigidbody-physics-section.html): enable physics-based behaviour such as movement, gravity, and collision.

  - Rigidbody2D: turns object into physics object with gravity

**4.  To Bird, add component Collider- ***Circle Collider 2D*** and adjust collider to preference.**

  > [Collider](https://docs.unity3d.com/Manual/2d-physics/collider/collider-2d-landing.html): enabling interactions and handling physical behavior in games, especially when combined with Rigidbody components.

**5.  To Bird, add new Script(ex: BirdScript) and double click to open VS.**

  > ### BirdScript
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

      > ### BirdScript
      >
      > ```csharp      > 
      >  public class BirdScript : MonoBehaviour
      >  {
      >  //references that can be /modifaccessedied from unity
      >  public Rigidbody2D myRigidbody; // gives script access to values in Rigidbody2d
      > 
      >  void Start() {
      > ```
      > -> Script component now has field for Ridibody 2D. Dragging Rigidbody 2D component will assign reference.

  2. Assign velocity when space is pressed.

     - Keyboard Input: Input.GetKeyDown(KeyCode._key name here_)
     - change velocity: myRigidbody (reference name from 6-1) . linearVelocity (vector for velocity direction) = _vector value_ (Vector2._direction_ is shorthand for vector direction - ex: Vector2.up == (0,1))
     - allow ease of testing and value changes create _public float flapStrength_ to change values in Unity Window
        <div align="center">
           <img src="https://github.com/user-attachments/assets/c0cbe21f-9d82-471c-a94f-6f0ed09f8559" alt="flapStrenghField.png" width="500">
        </div>

       > ### BirdScript
       >
       > ```csharp  
       > public float flapStrength; // preferably place above void Start()
       > 
       > void Update() {
       >   if (Input.GetKeyDown(KeyCode.Space) == true) //Input.GetKeyDown(KeyCode.Space)
       >   {
       >      myRigidbody.linearVelocity = Vector2.up * flapStrength;
       >      //Vector2.up == (0,1) -> changes velocity to move towards (0,1) of current position (times flapStrength)
       >    }
       >  }
       >  ```
---

## 3. Create Pipe

**1. Create Prefab for Pipes**
  > **[Prefab](https://docs.unity3d.com/Manual/Prefabs.html)**(Prefabricated Gameobjct): basically a blueprint for gameobjcts that can be resued
  1. Create new Gameobject("Pipes") and add child object *Top_Pipe*. Adjust position, size, rotation values as needed.
  2. Add BoxCollider2D component. (Rigidbody is not needed as it isn't affected by physics)
  3. Create code for pipe movement.

     > ### PipeMovement
     > 
     > ```csharp
     >   using UnityEngine;
     >  
     >  public class pipeMoveScript : MonoBehaviour
     >  {
     >    public float moveSpeed = 1f;
     >    public float deadZone = -11f;
     >  
     >    // Update is called once per frame
     >    void Update()
     >    {
     >        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
     >  
     >        if (transform.position.x < deadZone) {
     >            Debug.Log("Pipe Deleted");
     >            Destroy(gameObject);
     >        }
     >    }
     >  }
     >  ```
     >  - public floats for movementSpeed(speed of which the pipes move) and deadzone(area where pipes despawn)
     >  - change transform.position values to move left by value of Vector3.left (-1, 0) multiplied by moveSpeed.
     >    - movement value is multiplied by deltaTime to avoid issue of movement being tied to framerate (void Update is run every frame -> movement happens every frame
     >  > [deltaTime](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html): interval in seconds from the last frame to the current one
      -if statement to [destroy](https://docs.unity3d.com/ScriptReference/Object.Destroy.html) objecty if passing deadzone + [debug.log](https://docs.unity3d.com/ScriptReference/Debug.Log.html) to check destruction
  5. Copy-Paste *Top_Pipe* and add it as another child object of "Pipes". Adjust position, rotation, scale as needed.
  <div align="center">
    <img src="https://github.com/user-attachments/assets/3e3d2eff-6a0e-4768-83fe-1e3757096996" width="500" />
  </div>
  
  6. Drag gameObject from Hierarchy to Project Window to finalize Prefab creation. (You can delete Pipe from hierarchy afterwards)

**2. Create Pipe Spawner**
  1. Create new Gameobject("PipeSpawner") and adjuts position values as needed.
  2. Create script component and create reference for game object and(in Unity) drag Pipe prefab into reference field.
  3. In *void Update()* use Instantiate() to write code for spawning pipes.
    > Instantiate: create a new copy of an object, like spawning a new enemy or item in the game.
    >                   Instantiate(myPrefab, position, rotation);
  5. Create timer to space out spawning of Pipes.
  6. **To spawn pipes at differing heights** create public float heightoffset and within spawnPipe create float lowestPoint and highestPoint using heighoffset. (allows adjustment in Unity screen)
  7. Change position value in Instantiate to *new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint))*. Pipes will now spawn in random height within set range.
     
      > ### PipeSpawnScript
      >
      > ``` csharp
      > using UnityEngine;
      > using UnityEngine.Rendering;
      > 
      > public class PipeSpawnScript : MonoBehaviour
      > {
      >     public GameObject pipe;
      >     public float spawnRate = 2;
      >     private float timer = 0;
      >     public float heightOffset = 2.3f;
      > 
      >     // Start is called once before the first execution of Update after the MonoBehaviour is created
      >     void Start()
      >     {
      >         spawnPipe();
      >     }
      > 
      >     // Update is called once per frame
      >     void Update()
      >     {
      >         if (timer < spawnRate) {
      >             timer += Time.deltaTime;
      >         }
      >         else {
      >             spawnPipe();
      >             timer = 0;
      >         }
      >     }
      > 
      >     void spawnPipe() {
      >         float lowestPoint = transform.position.y - heightOffset;
      >         float highestPoint = transform.position.y + heightOffset;
      > 
      >         Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
      >     }
      > }
      > ```
      > - pipe spawn is made as function 'spawnPipe' to ease repetitive use

---

## 4. Logic Manager & UI

**1. Create Scoreboard**
  1. Create new object: Legacy/Text. Will need to zoom out to see the screen.
  2. Canvas/Canvas Scaler -> set to _'Scale With Screen Size'_ and set _Reference Resolution_.
  3. Set Text position, Width, Height, Font, Default Text, Text Color.
     ![image](https://github.com/user-attachments/assets/a6a75f45-b206-4879-8078-f196a200ba58)

**2. Create Logic Manager**
  1. Create new Game Object with script component _logicScript_
  2. Create code for saving, showing, modifying score

  > ### LogicScript
  > 
  > ```csharp
  > using UnityEngine;
  > using UnityEngine.UI;  // for 'Text' variable
  > 
  > public class LogicScript : MonoBehaviour {
  >     public int playerScore=0;
  >     public Text scoreText;
  >     public GameObject gameOverScreen;
  > 
  >     void Start() {
  >         playerScore = 0;
  >     }
  >     [ContextMenu("Increase Score")]
  >     public void addScore(int scoreToAdd) {
  >         playerScore += scoreToAdd;
  >         scoreText.text = playerScore.ToString();
  >     }
  > }
  > ```
  > - public reference for playerScore(int because lack of need for ) and scoreText
  > - to create/access a text variable there is a need _using UnityEngine.UI;_
  > - function is created for adding score and updating it to text (.ToString) and **[ContextMenu("Name_here")]** to access in Unity(allows testing)

**3. Trigger for score**
  1. Add gameObject that in the middle of Pipes with Box Collider 2D. To change shape change Size(in Collider) and check _Is Trigger_ and add script.
  2. Create code for adding score when collision is triggered.
     - Referencing won't work as Pipe will only exist when spawner starts making Pipes. Use **[Tag]**
       ![image](https://github.com/user-attachments/assets/06a4814f-ed59-4884-8a66-cec00e980f71)
       <div style="display: flex; justify-content: center; gap: 10px;">
          <img src="https://github.com/user-attachments/assets/6de5153e-763d-4f04-8074-c2d918a05f44" style="max-width: 45%;"/>
          <img src="https://github.com/user-attachments/assets/74db7808-7715-43eb-8d57-eb2f215f201d" style="max-width: 45%;"/>
        </div>
        - for ***Logic Manager*** object in Inspector Window create new Tag 'logic' and add tag 'logic' to Logic Manager(process done seperately)
        - code can now manually call object with Tag (single object with Tag excludes need for more specific finding)

       > ### PipeMiddleScript
       > 
       >  ```csharp
       >  using UnityEngine;
       >  public class PipeMiddleScript : MonoBehaviour
       >  {
       >      public LogicScript logic;
       >  
       >      void Start() {
       >          logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
       >          //find object with tag
       >      }
       >  
       >      private void OnTriggerEnter2D(Collider2D collision) {
       >          logic.addScore(1);
       >      }
       >  }

        ```
  4. Put bird in different layer to make sure that it is Bird that is passing middle.
  ![image](https://github.com/user-attachments/assets/4d05a00d-65a0-4326-aebb-6dcf06df1b2c)
        <div style="display: flex; justify-content: center; gap: 10px;">
          <img src="https://github.com/user-attachments/assets/e3e5d240-4c7a-4b3a-a094-2c7135d25f01" style="max-width: 45%;"/>
          <img src="https://github.com/user-attachments/assets/bca65d9c-227c-4369-b424-b884b28e9dc2" style="max-width: 45%;"/>
        </div>
        - allows checking if collision was on Bird's layer (+ future proof code by adding argument for addScore in LogicScript)
        
        > ### Pipe Middle Script
        >
        > ```csharp
        > private void OnTriggerEnter2D(Collider2D collision) {
        >     if (collision.gameObject.layer == 3) {
        >         logic.addScore(1);
        >     }        
        > }
        > ```
        
        > ### Logic Script
        > 
        > ```csharp
        > public void addScore(int scoreToAdd) {
        >     playerScore += scoreToAdd;
        >     scoreText.text = playerScore.ToString();
        > }
        > ```
---

## 5. Game Over Screen

** 1. Create game Over text and button **
  1. Create new gameObject Text, Button in Canvas object and adjust position, rotation, text.
![image](https://github.com/user-attachments/assets/d8e2adba-458f-4750-ab97-2988441bceff)
  - Button can call public function
  3.

