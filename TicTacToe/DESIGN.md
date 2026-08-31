# Design Notes - Tic-Tac-Toe Game

My first attempt at creating CRC (Class-Responsibility-Collaborator) cards.

| Class | Responsibilities | Collaborators |
|---|---|---|
| Game | Run the game until a winner or draw | Player, Round, Scoreboard |
| Round | Track board state<br>Check for a winner<br>Detect a draw<br>Display board | Player |
| Player | Get move from user | |
| Scoreboard | Track wins per player |  |