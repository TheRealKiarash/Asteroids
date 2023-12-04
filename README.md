# Asteroids

Wrote a small Asteroids to showcase my code design and thought process when it comes to code architecture.

## Design Approach
I followed the SOLID principles, Separation of Concerns, Functional Cohesion, and other programming best practices, but most of all, I tried to keep my code clean, intuitive, and simply readable as possible, *without* over-engineering it to the point of being counter-productive. I tried to keep a balance.

## A Bit More Detail:
I split the project into appropriate folders; Prefabs, Scenes, Scripts, and Sprites - each with their relative subfolders - but let's jump into the important part; the scripts:

For the Player, I divided the scripts into a PlayerShipMovement and a PlayerShooter script which is a subclass of BaseShooter (more on that later).

I started by implementing an Asteroid script which worked fine, but I thought it would be good practice to extract the BaseAsteroid class and have the subclasses inherit from that since functionality is slightly different, and it allows for expansion in the future. In the end I had a BaseAsteroid class which handles most of the functionality (Initialization, Destruction, shared variables) and 3 subclasses LargeAsteroid, MediumAsteroid, SmallAsteroid.

I also implemented saucers, and divided their functionality to Saucer and SaucerShooter scripts. The SaucerShooter script also inherits from the BaseShooter class, but has a unique implementation where it has an "inaccuracy angle" which changes based on the player score, becoming more accurate as the player progresses through the game and gets a higher score.

The BaseShooter is the base class for the PlayerShooter and SaucerShooter class, and they both implement a simple Bullet script which functions the same for both, with the difference of player and saucer bullets being only in the prefabs.

I implemented 3 manager classes to manage the game, all three implementing the singleton pattern:

	GameManager: Controls lives and score and overall game state.
	UIManager: Displays lives and score, and shows the Game Over screen when the player's lives run out.
	Spawner: Keeps track of the level and the spawning of enemies. (Side Note: I contemplated using the factory pattern for the Spawner but I thought that would veer into over-engineering so I avoided that)

and finally there was the ScreenWrapper component that I added to every object except the bullets in the game.
