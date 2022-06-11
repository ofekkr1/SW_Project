# Space rush - a multiplayer platform game
## introduction
Creating a new game requires a lot of work and knowledge, from the idea itself, to the interaction between different objects or inputs.
With the intention of learning the basics of game developing, we developed Space rush, where player can competete against each other, while facing different challenges throughout the game! just dont get caught by the laser....


## about the game
### The main Purpose
Up to 4 players are Competing against each other, as they need to constantly jump from one platform to another.
If a player is too low, he might get caught by the laser beam ascending as the game continues. Once a player touches the laser beam, he is out.
The game continues even after there is only one player remaining, as he can beat his previous score.

## how to play the game
The exe file is located in the "Build" folder, activate it and have fun!
***In order for the game to work, the whole "build" folder should be imported

### pre game functions
Every user will start at the main menu, from there, the user can choose 4 different options:

- **Play** - a user can create/join rooms(not before having a username)

- **How to play** - a short tutorial explaining the basic controls in game

- **options** - a scene where the user can control the music volume 

- **Exit** - completely exit the game

If the user chose play, he will be asked to name his player(must be non empty). After a shor loading, he will be moved to the room creation/joining scene.
The actions that a user can take in a lobby are:

- **customization** - a user has 4 player he can choose(4 different colors), which represents the player he will play in game.

- **Play** - starts the game ***(available only to the room host).*** 

- **Back** - the user exits the lobby, and is moved to the room creation/joining scene.


### in game function
Once the host starting the game, all players present will be spawned in the lowest platfom with the player's color adjusted by his user's choice.
Each player has the following Properties:

- a camera following him(for example, if I chose green player, my camera will follow my player). 

- the option moving left and right

- the option to jump(only from a surface)
  
The first time a player touches a high platform, they start descending.
A player can be disqualified by touching the laser.
Once a player disqualifies, his camera will follow the next player.

## Gallery
![Current tutorial](https://github.com/ofekkr1/SW_Project/blob/version_6/Assets/Images/How_to_play.jpeg?raw=true)
![Lobby](https://user-images.githubusercontent.com/94454456/173189583-acbf8f90-4503-4367-b611-379c22332a6c.jpeg?raw=true)
![Play1](https://user-images.githubusercontent.com/94454456/173189685-9761c089-7408-4928-89b9-8037859bff22.jpeg)
![Play2](https://user-images.githubusercontent.com/94454456/173189725-8d9e1a81-f92a-4e9c-ac9f-d6a2545ec3d6.jpeg)
![Play3](https://user-images.githubusercontent.com/94454456/173189745-e296eb6a-838b-4773-8e21-4d5cbc40cbb2.jpeg)
