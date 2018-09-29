# Kezyma.EloRating

Implementation of Elo rating system in C#

Usage:

Install the package from nuget: https://www.nuget.org/packages/Kezyma.EloRating/

        Install-Package Kezyma.EloRating -Version 1.0.0

To calculate the Elo resulting from a game, given the Elo of Player 1 and Player 2, The Result of the game for each player and the k factor for each player.

    // Player 1 with starting elo of 40
    // Player 2 with starting elo of 60
    // Player 1 wins, Player 2 loses, both have a k factor of 15.
    var newElo = EloCalculator.CalculateElo(40, 60, EloCalculator.WIN, EloCalculator.LOSE, 15, 15);
    var player1NewElo = newElo[0];
    var player2NewElo = newElo[1];
        
To predict the outcome of a game, given the elo of each player.

    // Player 1 with starting elo of 40
    // Player 2 with starting elo of 60
    var prediction = EloCalculator.PredictResult(40, 60);
    var player1Chance = prediction[0];
    var player2Chance = prediction[1];
