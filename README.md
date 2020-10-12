# AITris
A custom-made game of tetris, with an AI mode to watch an AI obliterate your records!


# My Motivation
AI is, no doubt, an exponentially growing topic in the field of Computer Science and Software Engineering. As I've made tetris previously in Visual Basic, I decided to spice things up, re-make it in Turing, and write & train an AI to also play the game, as an AI game mode!


# How It Works
- AITris essentially takes the current piece that's falling down, and tries it in every possible position from left to right(1-10), and every possible rotation(1-4)
- It then ranks each hypothetical placement by 4 factors: The number of lines it will clear, how much taller it will make the stack, how many top-covered holes it will create, and how evenly it will result in the stack being
- Using a machine learning model(a genetic algorithm), the co-efficients for each of these 4 factors were perfected
- Then, using the finalized co-efficient values, the AITris adds all of the values, and determines the best possible move
- It then executes the move, and then repeats


# Roadblocks/Challenges
- The biggest challenge was, I had no experience with AI before this project
- But through a bunch of research, and online tutorials, I managed to get a fully working tetris AI!
