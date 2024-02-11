<h1 align="center">
   Dreamland (previously Fantasy Farm)
</h1> 

   The project called "Dreamland" is a game, the essence of which is to discover all the territories and buildings on an unusual island, which consists of several islands, with different seasons, connected to each other by paths and bridges. They must be opened to the player with the help of resources that are mined by various mines or resource processors. 

<p align="center"> <img src="https://github.com/FMaksym/FantasyFarm/blob/main/Assets/Media/Image%201.png" width="800" height="560"/></p>

   The game is a very simple version of the Dreamdale game. Here I have implemented only a small part of the mechanics from the original game. For example: mines, processing plants, growing vegetables on the beds, growing fruit on the tree, storing and consuming various resources, teleports. In this project, I used an extended NavMesh called NavMeshSurface, with its help the player moved on the ground and with it I almost didn't use colliders, because the obstacles were defined with the help of Layers.

<p>In this project I implemented saving data into JSON files. Data about inventory, islands and buildings is saved in separate files. The player's level is saved in PlayerPrefs.</p>
   
<p>In the folders(Assets/Build) you can find a ready-made build for testing the game, you need to follow the link and download the apk file. </p>
   
<p>Game optimized for mobile(materials, meshes(Combine mesh), Occlusion culling, code).</p>

<h2 align="center">
   Gameplay video
</h2> 

<p>The result can be seen at the link in the video:</p>
 <div align="center">
  <a href="https://www.youtube.com/watch?v=RW89NrZ9zPE" >
    <img src="https://img.youtube.com/vi/RW89NrZ9zPE/0.jpg" alt="Смотреть видео" width="600" height="450">
  </a>
</div>

<h2 align="center">
   Link to build
</h2> 
   <p>Attention! After installing the project files, you will need to unzip the .rar file containing the game scenes, bacause the size of the game scene is a little more than 100MB</p>
   
   <p>Link to build:
https://github.com/FMaksym/FantasyFarm/blob/main/Assets/Build</p>

<h2 align="center">
   Implementation
</h2>
<p>During the development of the game I implemented:</p>
<ul><li>OOP;</li>  
<li>SOLID;</li>
<li>Zenject;</li>
<li>Singleton, Observer, Pool Objects;</li> 
<li>UI using MVVM;</li>
<li>In-App Purchase;</li> 
<li>DoTween;</li> 
<li>Cinemachine;</li> 
<li>Animator;</li> 
<li>NavMesh Surface;</li> 
<li>Joystick control;</li> 
<li>Factory systems;</li> 
<li>Inventory system;</li> 
<li>PlayerPrefs;</li> 
<li>Saving data in a JSON fil;e</li> 
<li>Optimization for a mobile device;</li> 
<li>Sound settings system.</li> </ul>  
<p>I wrote everything that I remember now, but that's not all.</p>

   <p>In the future I plan to add:</p>
<ul><li>The ability for the player to chop down trees and break stones;</li> 
<li>A dungeon with monsters that must be destroyed to get a reward at the end;</li> 
<li>Player upgrade system for resources obtained in dungeons;</li> 
<li>Customization for the player.</li> </ul> 
