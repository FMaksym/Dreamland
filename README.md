<h1 align="center">
   FantasyFarm
</h1> 

   The project called "Fantasy Farm" is a game, the essence of which is to discover all the territories and buildings on an unusual island, which consists of several islands, with different seasons, connected to each other by paths and bridges. They must be opened to the player with the help of resources that are mined by various mines or resource processors. 

<p align="center"> <img src="https://github.com/FMaksym/FantasyFarm/blob/main/Assets/Media/Image%201.png" width="800" height="560"/></p>

   The game is a very simple version of the Dreamdale game. Here I have implemented only a small part of the mechanics from the original game. For example: mines, processing plants, growing vegetables on the beds, growing fruit on the tree, storing and consuming various resources, teleports. In this project, I used an extended NavMesh called NavMeshSurface, with its help the player moved on the ground and with it I almost didn't use colliders, because the obstacles were defined with the help of Layers.

</p>In this project I implemented saving data into JSON files. The system for saving and loading data works fine, but as you can see, the DataManager class implements conditions for checking the type of device on which the project is running for the path where the data is saved. The reason for this condition is a problem with writing data to files on mobile devices. The project saves and reads data in the Unity Inspector without any problems, but not on mobile devices (empty files are created on them and nothing else). When you exit the game in mobile devices, all data will be lost.
   
   </p>In the folders(Assets/Build) you can find a ready-made build for testing the game, you need to follow the link and download the apk file. 
   
   </p>Game optimized for mobile(materials, meshes, source etc.).

</p>The result can be seen at the link in the video:
 <div align="center">
  <a href="https://www.youtube.com/watch?v=txLZUeV-SQk" >
    <img src="https://img.youtube.com/vi/txLZUeV-SQk/0.jpg" alt="Смотреть видео" width="600" height="450">
  </a>
</div>
   
   </p>Link to build:
https://github.com/FMaksym/FantasyFarm/blob/main/Assets/Build

