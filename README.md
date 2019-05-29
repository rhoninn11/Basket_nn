# Basket Ball _ Neural Network in Unity3D

The main goal of the project was to create a neural network algorithm in <b> C# </b> that could be used for throwing balls to basket with the highest precision.The project is adapted to <b> Unity3D </b>, but neural network algorithm has been written regardless of the requirements of the <b> Unity </b> - the engine has been used only for simple simulation, testing and verification. 

## User Interface 

There is only one Unity scene with the basket and the obstacle located on the ground. There is also simple GUI provided. By using its controls, the user is able to set main parameters for neural network, such as:
* <b> <i> Hidden layers' cound and size, </b> </i> 
* <b> <i> Time scale  </b> </i> - used for managing time during learning,
* <b> <i> Deviation factor </b> </i> - which means the initial distance between throwed balls,

There are three buttons called by names according to methods they are provided for: 
* <b> <i> Spawn Throwers </b> </i> - creates a simple cube with a random position and starts throwing 27 balls per Time in random directions with the distance between each other according to Deviation Factor,
* <b> <i> Populate new neural network </b> </i> - starts throwing balls to basket using naural network,
* <b> <i> Apply new time scale </b> </i> - sets the new Time Scale if the value of Slider is changed.

## Camera Control

There are two camera modes with two possible transforms: changing rotation and position. Both rotation and position applies to camera and coudn't be changed at the same time. By default the camera is in mode <i> Changing Position </i> and the user is able to press the arrows to move the camera in the scene. To set the mode to <i> Changing Rotation </i>, the user needs to click the <i> M </i> key and start moving the Mouse. 








