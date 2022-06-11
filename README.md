# Space rush - a multiplayer platform game
## introduction
Creating a new game requires a lot of work and knowledge, from the idea itself, to the interaction between different objects or inputs.
With the intention of learning the basics of game developing, we developed Space rush, using unity as our engine, and Photon as our multiplayer infrastructure.


## about the game
### The main Purpose
Up to 4 players are Competing against each other, as they need to constantly jump from one platform to another.
If a player is too low, he might get caught by the laser beam advancing as the game continues. Once a player touches the laser beam, he is out.
The game continues even after there is only one player remaining, as he can beat his previous score.


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

![Current tutorial](https://github.com/ofekkr1/SW_Project/blob/version_6/Assets/Images/How_to_play.jpeg?raw=true)

