# lightscale

lightscale is a mobile game which is still in development. Based on the theme "move the environment, not the player", the user controls a touch-based light to lure a moth towards to its goal, while avoiding obstacles and light. However, every light source is deadly, so the player needs to keep their distance.

## Features
### Tile Based Level Generator
The level generator creates a random tile-based map. Each tile is screensized. From a starting tile, the map adds tiles into all four directions, based on a spawnprobability.
The minimum and maximum amount of tiles that can be spawned can be adjusted, and a random amount between that range will be generated.

![Example for a Generated Map](/assets/images/LevelGenerator.JPG)
![Example for a Generated Map](/assets/images/LevelGenerator2.JPG)

### Asset Database
A database made of scriptable objects supports the seperation of art and programming. Each object holds a reference for future artwork and prefab settings, which are automatically applied by the Levelgenerator and loaded in at random positions on the map based on the object specific probability to spawn. 

### Player behaviour
Light attracts the player, and makes it automatically towards it, depending on the light intensity

## License
[MIT](https://choosealicense.com/licenses/mit/)
