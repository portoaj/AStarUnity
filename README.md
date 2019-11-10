# AStarUnity
Generates a series of water and grass tiles and dynamically finds the shortest path from the player to the target using the A* algorithm.  Demo video included.

**Usage:**
1. Download and open the AStar folder in Unity.  The current Unity Project version is 2019.3.0a4
1. Open the demoscene and click the play button
1. A series of tiles should spawn
1. Enable gizmos and click on the PlayerDemo GameObject in the hierarchy to show the trail
1. You can move the player using the arrow keys or a controller and the trail will update dynamically


**Note:**
A* allows for node weighting, and in this case the water nodes have a weight of two and the grass nodes have a weight of one.  This means the path will usually steer towards grass, only crossing water tiles as necessary.

**Sources:**
* https://en.wikipedia.org/wiki/A*_search_algorithm,
* http://mat.uab.cat/~alseda/MasterOpt/AStar-Algorithm.pdf
* https://medium.com/@nicholas.w.swift/easy-a-star-pathfinding-7e6689c7f7b2
