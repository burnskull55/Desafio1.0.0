namespace DesafioClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="CoupModel" />.
    /// </summary>
    public class CoupModel
    {
        /// <summary>
        /// Defines the teamsForCoup.
        /// </summary>
        internal List<TeamModel> teamsForCoup = new List<TeamModel>();

        /// <summary>
        /// Defines the teamsInCoup.
        /// </summary>
        internal List<TeamModel> teamsInCoup = new List<TeamModel>();

        /// <summary>
        /// Defines the teamsFinal.
        /// </summary>
        internal List<TeamModel> teamsFinal = new List<TeamModel>();

        /// <summary>
        /// Defines the firstP.
        /// </summary>
        public TeamModel firstP;

        /// <summary>
        /// Defines the secondP.
        /// </summary>
        public TeamModel secondP;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoupModel"/> class.
        /// </summary>
        /// <param name="teamsForCoup">The teamsForCoup<see cref="List{TeamModel}"/>.</param>
        public CoupModel(List<TeamModel> teamsForCoup)
        {
            this.teamsForCoup = teamsForCoup;
        }

        /// <summary>
        /// The orderCoup.
        /// </summary>
        public void orderCoup()
        {
            this.teamsForCoup = this.teamsForCoup.OrderBy(c => Int32.Parse(c.nome.Trim().Substring(c.nome.Trim().IndexOf(" ")))).ToList();
        }

        /// <summary>
        /// The firstPhase.
        /// </summary>
        public void firstPhase()
        {
            GameModel game1 = new GameModel();
            GameModel game2 = new GameModel();
            GameModel game3 = new GameModel();
            GameModel game4 = new GameModel();
            //
            game1.teamA = this.teamsForCoup[0];
            game1.teamB = this.teamsForCoup[7];
            game1.makeGame();
            teamsInCoup.Add(game1.winner);

            game2.teamA = this.teamsForCoup[1];
            game2.teamB = this.teamsForCoup[6];
            game2.makeGame();
            teamsInCoup.Add(game2.winner);

            game3.teamB = this.teamsForCoup[2];
            game3.teamB = this.teamsForCoup[5];
            game3.makeGame();
            teamsInCoup.Add(game3.winner);

            game4.teamA = this.teamsForCoup[3];
            game4.teamB = this.teamsForCoup[4];
            game4.makeGame();
            teamsInCoup.Add(game4.winner);
        }

        /// <summary>
        /// The secondPhase.
        /// </summary>
        public void secondPhase()
        {
            GameModel game1 = new GameModel();
            GameModel game2 = new GameModel();

            game1.teamA = this.teamsInCoup[0];
            game1.teamB = this.teamsInCoup[1];
            game1.makeGame();
            this.teamsFinal.Add(game1.winner);

            game2.teamA = this.teamsInCoup[2];
            game2.teamB = this.teamsInCoup[3];
            game2.makeGame();
            this.teamsFinal.Add(game2.winner);
        }

        /// <summary>
        /// The finalPhase.
        /// </summary>
        public void finalPhase()
        {
            GameModel gameF = new GameModel();
            gameF.teamA = this.teamsFinal[0];
            gameF.teamB = this.teamsFinal[1];
            gameF.makeGame();
            this.firstP = gameF.winner;
            this.secondP = gameF.loser;
        }
        /// <summary>
        ///  
        /// </summary>
        public void testFirstPhase()
        {
            Console.WriteLine("teste: mostrando a ordem das equipes que estao na primeira fase");
            foreach (TeamModel team in this.teamsForCoup)
            {
                Console.WriteLine(team.nome);
            }
        }
        public void testSecondPhase()
        {
            Console.WriteLine("teste: mostrando a ordem das equipes que estao na segunda fase");
            foreach (TeamModel team in this.teamsInCoup)
            {
                Console.WriteLine(team.nome);
            }
        }
        public void testFinalPhase()
        {
            Console.WriteLine("teste: mostrando a ordem das equipes que estao na final");
            foreach (TeamModel team in this.teamsFinal)
            {
                Console.WriteLine(team.nome);
            }
        }
    }
}
