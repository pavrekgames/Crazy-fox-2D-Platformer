# Crazy-fox-2D-Platformer

Simple 2D platformer game where you must collect cherries and reach the certain point to finish level.

USED PACKAGES:

* SunnyLand Artwork - Sprites, animations, Tile pallet
* DOTween (HOTween v2) - To animate the moving platforms
* New Input System - Player movement

FEATURES:

- Player can move left and right
- Player can jump
- Player can climb up and down on ladders
- Player dies when he touches spikes, holes, or an enemy
- Player has 3 lives on the level
- Player has to collect the required amount of cherries and reach the finish point to complete level
- Player can collect gems ( The gem is a particular item that is hard to collect.)
- In the game, there are moving platforms with various speeds (Horizontal and vertical)
- In the game, there are 3 types of enemies
  * Dog - Moving left and right with constant speed on the ground.
  * Eagle - Moving left and right at a higher speed in the air.
  * Slimer - Moving left and right with jumping.
- The game has 4 levels:
  * Level 1: Simple level to know the mechanics (Some holes, One spike)
  * Level 2: More spikes and holes, Added ladders.
  * Level 3: Holes, spikes, ladders, and added moving platforms
  * Level 4: Holes, spikes, ladders, platforms, and added enemies.
- When the player loses all lives, the game loads the main menu scene.
- The player can choose the current level when he unlocks it.

USED DESIGN PATTERNS:

- Singleton Pattern: Game Manager, Audio Manager, Menu, Don't Destroy on Load.
- Observer Pattern: Updating UI and other events.
- State Pattern: Default moving of player and moving on ladders.
- Strategy Pattern: Enemies' behavior
- Prototype Pattern: Scriptable objects of levels data

SCREENSHOTS

![CrazyFoxScreen_1](https://github.com/pavrekgames/Crazy-fox-2D-Platformer/assets/105421661/bcc6a848-8f45-4b51-8d9c-b21be737bf50)

![CrazyFoxScreen_2](https://github.com/pavrekgames/Crazy-fox-2D-Platformer/assets/105421661/79ba8c38-84e2-4ebb-b423-4bb574ecf1a5)

![CrazyFoxScreen_3](https://github.com/pavrekgames/Crazy-fox-2D-Platformer/assets/105421661/295c9cb4-4a98-4538-abfc-4f424cae2bed)

![CrazyFoxScreen_4](https://github.com/pavrekgames/Crazy-fox-2D-Platformer/assets/105421661/7beb0b03-407c-496c-9964-a908f61f468b)

![CrazyFoxScreen_5](https://github.com/pavrekgames/Crazy-fox-2D-Platformer/assets/105421661/782fadb7-f103-4973-8c8f-9e45edf39c36)



