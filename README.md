# dRuBbLe in 3-D
_A Silly Game With Silly Stools_

The smash hit game dRuBbLe in 3-D using the Unity engine.
The objective is to bounce a ball on top of a stool, either to cover the maximum distance, or to compete in a volleyball-like sport.
In the background are landmarks from Washington, DC.
dRuBbLe was previously written in pure Python code using the [Kivy](kivy.org) multiplatform development engine.

![First look graphic with the dRuBbLePunk in front of the Capitol](images/d3firstLook.jpg)

## Unity Editor Components

### Kinematics

### Character

### Animation

### Rigging

## Scripting Components

The script controlling an individual dRuBbLe player is called [Player.cs](dRuBbLe3D/Assets/Player.cs).
This accesses the `GameObject`s that handle character kinematics, animations, interactions with the ball, and camera motion.
Left/right, up/down, and stool rotation and extension motions are also handled here via user inputs and/or computer controls.

### Properties

Several `GameObject`s are accessed via public properties, with the referenced objects being added via the graphical editor, not script.
These include the `player` and `stool`, which reference the kinematic components, as well as the `ball` and `mainCamera`.
Additionally, the player `animator` is included as a public property.

Rigid bodies for the `player` and `stool` are accessed in the `Start()` method, where they are retained as private properties, and updated on each frame.
Other private properties include the keyboard keys associated with each type of movement, and the force magnitudes to be applied when the corresponding key is pressed.

### Controls

Keyboard inputs are handled in the `KeyboardControls()` method, which is called each time `Update()` is called.
The main left/right and up/down movements use WASD keys, which will correspond to forces applied in the X or Y direction on the `body`.
The stool can be rotated about the Z axis, or extended in the Y axis of the rotated frame using arrow keys.

### Camera
