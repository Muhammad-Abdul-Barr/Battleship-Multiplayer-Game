# Battleship Multiplayer Game
C# Server - Client Battleship Board Game Using Sockets And TCP Protocol.
Made By: 
-Muhmmad Abdul Barr 2022-CS-131
-Shehroz Ahmed      2022-CS-157
Department of Computer Science
UET, Lahore.

## Project Description:
The Battleship game project focuses on recreating the traditional two-player game in a digital format that works over a computer network. The main aim is to provide an interactive and enjoyable experience for players while ensuring smooth communication between them. Here are the main goals of the project:
•	Build an application where two players can connect with each other and play the game in real time.
•	Ensure that the game follows all the official rules of Battleship, such as turn-based gameplay and correct handling of hits and misses.
•	Design a user-friendly interface so players can easily place their ships, make moves, and track the game progress.
•	Use socket programming to handle turns between players without lag or interruptions.
The project scope includes multiplayer functionality implemented using socket programming, real-time communication, and rule enforcement. This project covers connection between two devices where one act as a server and other acts as a client rather than multiple players communicating to each other through a server, this is why only one game can be hosted at a time between two players only.
To achieve these goals, we used C# for coding the game, WinForms for creating a user-friendly UI and socket programming to handle network communication. The communication happens over TCP connection. Players can connect over a local network ensuring fairness and proper gameplay.
Through this project, we aimed to understand the challenges of creating a multiplayer system and how to solve them effectively. This experience will help us in future projects that involve networking and real-time applications.

## Game Rules
2 players are required to play the game.<br/>
Players each have a fleet of 10 ships: 1 x Battleship, 2 x Cruisers, 1 x Destroyers<br/>
Players must place 10 ships in 10x10=100 boxes.<br/>
Players then attack each other to ruin the enemy's Battleship. The player whose Battleship ruins loses the game.<br/>


Number of squares covered by ships: <br/>
Battleship: 4<br/>
Cruiser: 3<br/>
Destroyer: 2<br/>


## Materials and Methods<br/>
- Form1.cs and Server.cs:<br/>
Communication in the project was provided with TCP/IP protocols.<br/>
The project consists of 2 WinForm(.NET Framework) projects in 1 solution.<br/>
On the server side, Server.cs creates a socket based on the information from Form1 and listens for incoming requests.<br/>
On the client side, Client.cs sends a connection request from the specified Port Number to the IP Address from Form1.<br/>
Once connected, players can proceed to the "Game Preparatory" phase.<br/>
Note: Port is any free port.<br/>

- Form2:<br/>
There are 100 Buttons to place the fleet in the game preparation phase,<br/>
There is 1 Button to go to the next stage,<br/>
There is 1 "ToolStripMenu" that explains the game rules when clicked,<br/>
There is 1 "Remaining Ships" interface for the number of ships that need to be deployed.<br/>
>Ships are created from the Ship.cs class and are stored in an array. After the ship is added, the properties of the object are updated. </br>
The Drawing2D library is used to select the area where the ship will be placed. A rectangular drawing is started by clicking on the form with the mouse, when the click is released, the Name property of the button is sent.<br/>
The **Form3.cs** page is displayed, where the ship that can be placed will be selected according to the number of boxes selected. If "Save" is called, the ship is placed in the relevant field and the related ship properties are updated in the object array of 'Ship' type.<br/>
Once the player has placed her entire fleet, he/she can start the game.<br/>

- Form4:<br/>
This interface is the screen where the game is played. There are 100 Buttons that show the Player's fleet, 100 Buttons to attack, and a "RichTextBox" that gives feedback to the Player.<br/>
>"StreamWriter" and "StreamReader" objects perform sending and receiving data,<br/>
Two "BackgroundWorker" objects run these two streams in the background.<br/>
Who will start the game is determined randomly. Data 0 or 1 is sent depending on the result.<br/>
When the player attacks, the coordinate is sent. Depending on the hit status of the attack, action is taken on the relevant ship object. Feedback is received on the outcome of the attack.<br/>
The interface is updated on both sides based on attacks and feedback.<br/>
The side whose "Battleship" buttons are destroyed loses the game.<br/>
