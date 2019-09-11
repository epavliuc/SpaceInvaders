# SpaceInvaders
Space invaders, this is a 3 day long project in which I have to create a game resempling the style of the Classical Space invaders. The goal is not to create a copy but to develop on the knowledge how each given feature is implemented within the game.

### 
### Functions to implement
```
Player controls:
  -The player should be able to move from side to side on the canvas using the arrow keys(Only side to side).
  
What was achieved:
  -This was achieved using event listeners, on keydown it would move to the side specified.
  
Enemy spawn:
  -The enemies are meant to spawn at the top of the screen and should progress towards the bottom of the screen. If enemies reach the        bottom of the screen then the game is lost. 

What was achieved:
  -Enemies do appear on the screen and the appropate animation was achieved using a timer which calls a method every 10milliseconds(every    10millisecond it moves 1pixel)
  -Due to time constraints I was not able to achieve a satisfactory effect and verification methods of the enemies                           de-spawning/dissapearing. This effect would allow the creation of a "Game complete" screen once all the enemies get distroyed.
  
Bullet spawn:

Object collision:
Game Won Screen:
Game Over Screen:
Menu Screen:
```
