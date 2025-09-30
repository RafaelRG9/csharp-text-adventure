# C# Text Adventure: Manor Escape

Trapped within the cold stone walls of a forgotten manor, your only goal is to find a way out. This classic text-based adventure game was built in C# as a foundational project to explore object-oriented design and core game development principles.



## Features

* **A Multi-Room World to Explore:** Navigate a grid-based world, moving between distinct locations like a dusty library and a mysterious alchemy lab.
* **Interactive Item System:** Find, `take`, and `drop` items scattered throughout the manor.
* **Player Inventory:** Manage your inventory with the `inventory` (or `i`) command to see what you're carrying.
* **Robust Command Parser:** A flexible command parser understands actions like `take rusty key`, aliases (`l` for `look`), and provides clear feedback for invalid commands.
* **A Central Puzzle:** Use your wits (and your inventory!) to solve the locked door puzzle and win the game.

## Technologies Used

* C#
* .NET

## How to Run

1.  Clone the repository:
    ```sh
    git clone https://github.com/RafaelRG9/csharp-text-adventure
    ```
2.  Navigate to the project directory:
    ```sh
    cd csharp-text-adventure
    ```
3.  Run the application:
    ```sh
    dotnet run
    ```

## Learning Journey & Key Concepts

This project was a hands-on exercise in building a complete application from the ground up, focusing on clean code and scalable architecture. The key concepts I implemented include:

* **Object-Oriented Design:** Creating distinct classes for `Player`, `Room`, `Item`, and `World` to cleanly separate responsibilities and manage the game's state effectively.
* **State Management:** Tracking the player's location and inventory, as well as the state and location of all items within the world.
* **Command Parsing & Handling:** Refactoring an initial `if/else` command structure into a scalable, `switch`-based parser capable of handling multi-word commands and aliases.
* **Data Structures:** Applying `List<T>` for managing player and room inventories and creating a graph-like structure by linking room objects together.
* **Clean Code & Refactoring:** Improving the game's flow and user experience by creating helper methods (like `DescribeRoom`) and refining the main game loop to be more efficient and readable.