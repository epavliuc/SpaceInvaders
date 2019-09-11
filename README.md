# SpaceInvaders
Space invaders, this is a 3 day long project in which I have to create a game resempling the style of the Classical Space invaders. The goal is not to create a copy but to develop on the knowledge how each given feature is implemented within the game.

### Functions Implemented

## Player controls:
```
-The player should be able to move from side to side on the canvas using the arrow keys(Only side to side).
  
What was achieved:
-This was achieved using event listeners, on keydown it would move to the side specified.
```

## Enemy spawn:
```
-The enemies are meant to spawn at the top of the screen and should progress towards the bottom of the screen. If enemies reach the        bottom of the screen then the game is lost. 

What was achieved:
-Enemies do appear on the screen and the appropate animation was achieved using a timer which calls a method every 10milliseconds(every    10millisecond it moves 1pixel)
-Due to time constraints I was not able to achieve a satisfactory effect and verification methods of the enemies                           de-spawning/dissapearing. This effect would allow the creation of a "Game complete" screen once all the enemies get distroyed.
```  

## Bullet spawn:
```
-The bullets are meant to spawn at the position of the player and move upwards towards the enemies.
 
What was achieved:
-The bullet spawn and animation was implemented successfully, the speed can be adjusted and damage of the bullets can be changed too.
 ``` 
 
## Object collision:
```
-The collision between the enemy and the bullet is meant to be detected and appropiate events must take place(hp of enemy must be changed or enemy must disappear if dead)

What was achieved:
-The collision was achieved successfully, currently each bullet does 50dmg and each enemy has 100hp, which means the enemy must be hit twice to disappear.
```
### Unimplemented Functions
## Game Won Screen:
```
-While the collision works, due to time constrains as I was not able to implement a way of detecting when all enemies are defeated.
```
## Game Over Screen:
```
-While the collision works, due to time constrains as I was not able to implement a way of detecting when the enemies have reached the bottom of the screen.
```
## Menu Screen:
```
-Due to time constrains as I was not able to implement a menu from which the user can start a new game.
```
### Issues throughout the project
```
Unfortunatly I was unable to work on the project for the given timeframe, on 09/09/2019 I was not available to do so. Due to this, I failed to implement all desired features.
```
