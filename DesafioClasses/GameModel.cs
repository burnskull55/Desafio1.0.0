namespace DesafioClasses
{
    /// <summary>
    /// Defines the <see cref="GameModel" />.
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Defines the teamA.
        /// </summary>
        public TeamModel teamA = new TeamModel();

        /// <summary>
        /// Defines the teamB.
        /// </summary>
        public TeamModel teamB = new TeamModel();

        /// <summary>
        /// Defines the winner.
        /// </summary>
        public TeamModel winner = new TeamModel();

        /// <summary>
        /// Defines the loser.
        /// </summary>
        public TeamModel loser = new TeamModel();

        /// <summary>
        /// The makeGame.
        /// </summary>
        public void makeGame()
        {
            if (teamA.gols >= teamB.gols)//devido ao chaveamento o time A sempre eh o primeiro em ordem alfabetica, logo ele sempre ganha os empates
            {
                winner = teamA;
                loser = teamB;
            }
            else
            {
                winner = teamB;
                loser = teamA;
            }
        }
    }
}
