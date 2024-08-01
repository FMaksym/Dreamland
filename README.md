<h1 align="center"> Dreamland </h1> 

   The project called "Dreamland" is a game, the essence of which is to discover all the territories and buildings on an unusual island, which consists of several islands, with different seasons, connected to each other by paths and bridges. They must be opened to the player with the help of resources that are mined by various mines or resource processors. 

<p align="center"> <img src="https://github.com/FMaksym/FantasyFarm/blob/main/Assets/Media/Image%201.png" width="800" height="560"/></p>

   The game is a very simple version of the Dreamdale game. Here I have implemented only a small part of the mechanics from the original game. For example: mines, processing plants, growing vegetables on the beds, growing fruit on the tree, storing and consuming various resources, teleports. In this project, I used an extended NavMesh called NavMeshSurface, with its help the player moved on the ground and with it I almost didn't use colliders, because the obstacles were defined with the help of Layers.

<p>In this project I implemented saving data into JSON files. Data about inventory, islands and buildings is saved in separate files. The player's level is saved in PlayerPrefs.</p>
   
<p>In the folders(Assets/Build) you can find a ready-made build for testing the game, you need to follow the link and download the apk file. </p>
   
<p>Game optimized for mobile(materials, meshes(Combine mesh), Occlusion culling, code).</p>

<h2 align="center"> Implementation </h2>
   
<p>During the development of the game I implemented:</p>

* OOP;
* SOLID;
* Zenject;
* Singleton, Observer, Pool Objects; 
* UI using MVVM;
* In-App Purchase;
* DoTween; 
* Cinemachine; 
* Animator;
* NavMesh Surface;
* Joystick control;
* Factory systems; 
* Inventory system; 
* PlayerPrefs;
* Saving data in a JSON file; 
* Optimization for a mobile device; 
* Sound settings system.
<p>I wrote all that I remember now, but that's not all.</p>

<h2 align="center"> Gameplay video </h2> 

<p>The result can be seen at the link in the video:</p>
 <div align="center">
  <a href="https://www.youtube.com/watch?v=RW89NrZ9zPE" >
    <img src="https://img.youtube.com/vi/RW89NrZ9zPE/0.jpg" title="Watch video" width="600" height="450">
  </a>
</div>

<h2 align="center"> Download build </h2>

> Attention! If you want to play this game you will need to install the .rar file due to the fact that the build is temporarily not optimized in size and takes up a little more than 100MB.
   
You can download the latest version of the game [here](https://github.com/FMaksym/Dreamland/raw/main/Assets/Build/DreamLand.rar).

<h2 align="center"> In the future </h2>
   <p>In the future I plan to add:</p>
   
* The ability for the player to cut down trees and break rocks;
* A generated dungeon with monsters that must be destroyed in order to receive a reward at the end and return to the surface;
* Player improvement system for resources obtained in dungeons;
* Player customization. 

<h2 align="center"> In progress </h2>

Currently, work is underway on the ability to chop down trees and stones, the dungeon scene and the system for interacting with opponents.
Here are screenshots of the completed work:

<p align="center">
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/CutTree_foto.png" title="Cut Tree" width="200"/>
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/CutTreeFinish_foto.png" title="Cut Tree Finish" width="200"/>
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/CutStone_foto.png" title="Cut Stone" width="200"/>
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/CutStoneFinish_foto.png" title="Cut Stone Finish" width="200"/>
</p>

<p align="center">
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/Dungeon_foto.png" title="View of the dungeon in the game" width="250"/>
  <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/Dungeon2_foto.png" title="View of the dungeon in the game" width="250"/>
</p>

<p align="center">
   <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/DungeonScene1_foto.png" title="Dungeon Scene" width="750"/> 
   <img src="https://github.com/FMaksym/Dreamland/raw/main/Assets/Media/DungeonScene2_foto.png" title="Dungeon Scene" width="750"/>
</p>
