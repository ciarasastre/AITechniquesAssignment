# AITechniquesAssignment
Welcome to HoneyPark! HoneyPark is a playground filled with kids playing, bees busily working and mischief all round!

**Important Note:** The proper file is the HONEYPARKBACKUP FILE the previous one broke and i was too scared to remove it or touch it but the HONEYPARKBACKUP works perfectly fine!</br>

**The Controls** </br>
Make sure you are on SCENE 2 and press PLAY this will start the cinematic for you. SCENE 1 is just a tester and does nothing!</br>

**How Does Everything Work?** </br>
There are two groups of kids chasing each other one group of kids uses boids and a trigger event to swap roles and chase the other </br>The next group of kids are controlled using a state machine there is a chase state and a run state depending on how they collide with each other will chage their states. </br>
The Bees work as a flocking mechanism they are given a certain size box to stay within if they stray too far they must go back in range. The will do their best to group up with their fellow bees to swarm together.</br>
The birds fly in a normal boid fashion nothing too impressive about them.</br>
The Camera work was done with creating scenes within Cinemachine the scenes are located in the hierarchy and </br>
you can view the entire show by clicking the TIMELINE in the hierarchy.</br>

**What tutorials did I use for help?** </br>
I used Boid and steering behaviours from what we learnt in class. I watched multiple flocking videos on youtube to figure out how to get the bees to swarm (Took a long time for me to understand). Learnt state machines in a youtube video about rpg games and im obsessed with state machines now. Learnt particles from youtube videos as well and after that i played around with the particles to get whatever effect i wanted.</br>

**What am I most proud of?** </br>
I honestly will say that this assignment is by far my favourite that i have made. Im really proud of how it came out! I have two favourite parts of this cinematic. The first one is the bee segment where "Flight of the bees" gets played and Barry B Benson makes an appearance saying "Dya Like Jazz" quoting a line from The Bee Movie. </br>
My second favourite part is the ending scene where the kids go to the part late at night and all the bees and birds light up with partile effects. I took so long making these scenes because I genuinly enjoyed making them!

**Video on Youtube** </br>
[![YouTube](/Images/tn.jpg)](https://www.youtube.com/watch?v=FrmfldXzOHM)

**Layout**</br>
![Layout](/Images/layout.jpg) </br>

The above is the intended layout of HoneyPark. The main playground is at the center of the park </br>
Positioned at the **top left** there are two kids that will be playing tag. When one kid catches the next kid they switch </br>
roles and chase the opposite person. </br>
Positioned at the **top right** is a bee hive full of busy bees. These bees will travel around honeypark collecting pollen and nectar from </br>
the miscellaneous flowers around and return to their beehive to store it. The bees will not bother the player unless </br>
the player **decides to hit the beehive** if the player does this a swarm of bees will chase and attack the player. </br>
There will also be a lake on the **bottom right** and a forest on the **bottom left**. </br>
At the playground just behind the bench will be an **ant mound** where ants will come out in a line to gather crumbs it finds </br>
around the floor. 

**StoryBoard**</br>
![Layout](/Images/story.jpg) </br>
The above is the storyboard for this assignment. </br>
1) This picture will pan the intro to the left side of the park. </br>
2) This picture will pan the intro to the right side of the park. </br>
3) This picture shows the two kids running around in the park. </br>
4) This camera angle will show the bees collecting pollen and ectar from the flowers. </br>
5) This camera angle will show 1 how the player can attack the beehive. </br>
and part 2 can show how if you choose to do this, you will be attacked by a swarm of bees. </br>
6) This camera angle will show the player being chased by bees. For a gameplay point of view i might implement the choice of </br>
going through a hedgemaze to show how to bees will navigate through it will focusing you. If not the movie will end with the  </br>
player jumping into the lake to save him/herself from th bees attack </br>
EXTRA) I might add Barry Bee Benson from the Bee Movie as an easter egg to this assignment but im not sure how serious we need  </br>
to make this assignment. </br>


