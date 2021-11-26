# unity2d-starter

A bare bones sample project for a 2D Unity game.

## Scenes

The project includes 3 scenes:
- TitleScene.unity is a landing screen for startup. Pressing space from the title screen starts the game and loads... 
- Main.unity contains a (very) simple platformer with a player, platforms, and obstacles. The game ends when the player falls from the platform, loading ...
- Credits.unity loads when the game finishes. Pressing any key exits the application.

## Scripts

The game includes five rudimentary C# scripts:
- StartGame.cs loads the Main scene when the spacebar is pressed. It is connected to the Main Camera in TitleScene.
- CameraController.cs defines a public Transform that should be set to the player object. The camera will follow the player at a given X and Y offset.
- GameOver.cs detects when the player has fallen below a given Y coordinate and loads the Credits scene. It is attached to the Main Camera in the Main scene.
- Player.cs controls player movement. Move the player left and right using S and D or arrow keys, and jump using the spacebar. It is attached to the Player GameObject.
- Quit.cs detects a keypress and quits the application. It is attached to the Credits scene Main camera.

## Building and Playing

The project includes two placeholder logos that will appear when the game is built and played (See Player Settings). The TitleScene should be loaded first (See Build Settings.) Be sure all three scenes have been added to the build.
