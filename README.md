# Basket Ball _ Neural Network in Unity3D

The main goal of the project was to create a neural network algorithm in <b> C# </b> that could be used for throwing balls to basket with the highest precision.The project is adapted to <b> Unity3D </b>, but the neural network algorithm has been written regardless of  requirements of the <b> Unity </b> platform - the engine was used only for simple simulation, testing and verification. 

## User Interface 

There is only one Unity scene with the basket and the obstacle located on the ground. There is also simple GUI provided. By using its controls, the user is able to set main parameters for neural network, such as:
* <b> <i> Hidden layers' count and size, </b> </i> 
* <b> <i> Time scale  </b> </i> - used for managing time during learning,
* <b> <i> Deviation factor </b> </i> - which means the initial distance between throwed balls,

There are three buttons called by names according to methods they are provided for: 
* <b> <i> Spawn Throwers </b> </i> - creates a simple cube with a random position and starts throwing 27 balls per Time in random directions with the distance between each other according to Deviation Factor,
* <b> <i> Populate new neural network </b> </i> - starts throwing balls to basket using naural network,
* <b> <i> Apply new time scale </b> </i> - sets the new Time Scale if the value of Slider is changed.

![](https://raw.githubusercontent.com/rhoninn11/Basket_nn/master/5.PNG)
![](https://raw.githubusercontent.com/rhoninn11/Basket_nn/master/6.PNG)

## Camera Control

There are two camera modes with two possible transforms: changing rotation and position. Both rotation and position applies to camera and coudn't be changed at the same time. By default the camera is in mode <i> Changing Position </i> and the user is able to press the arrows to move the camera in the scene. To set the mode <i> Changing Rotation </i>, the user needs to click the <i> "M" </i> key and start moving the Mouse. 

## Neural Network in C# 

The algorithm is prepared for using not only in Unity engine but also for different platforms. All the main parts of the network are clearly described in separated classes. The neural network learns according to initial position of the cube and the target point which is the basket's location. It 'looks for' the best precision for throwing with the most optimized ball's trajectory. In every 27-balls group there is one ball with the red color and it means the ball throwed with the neural network algorithm. All the other balls are thrown in the close distance from it.  








