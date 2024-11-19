using Wsi.NovaCentauri.Cons.Models;

namespace Wsi.NovaCentauri.Cons.Services
{
    public class BattleService
    {

        private void Battle(Game game)
        {
            while (game.TeamA.Count > 0 && game.TeamB.Count > 0)
            {
                Fighter fighterA = game.TeamA[0];
                Fighter fighterB = game.TeamB[0];

                if (fighterB.Speed > fighterA.Speed)
                {
                    fighterA.Health -= fighterB.Strength;
                    if (fighterA.Health <= 0)
                    {
                        game.TeamA.RemoveAt(0);
                    }
                    else
                    {
                        fighterB.Health -= fighterA.Strength;
                        if (fighterB.Health <= 0)
                        {
                            game.TeamB.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    fighterB.Health -= fighterA.Strength;
                    if (fighterB.Health <= 0)
                    {
                        game.TeamB.RemoveAt(0);
                    }
                    else
                    {
                        fighterA.Health -= fighterB.Strength;
                        if (fighterA.Health <= 0)
                        {
                            game.TeamA.RemoveAt(0);
                        }
                    }
                }

            }
        }

        private int TotalFighterHealth(IEnumerable<Fighter> fighters)
        {
            return fighters.Select(fighter => fighter.Health).Sum();
        }

        public GameResult Run(Game game)
        {
            Battle(game);
            int remainingHealth;
            string winningTeam;
            if (game.TeamA.Count > 0)
            {
                remainingHealth = TotalFighterHealth(game.TeamA);
                winningTeam = "TeamA";
            }
            else {
                remainingHealth = TotalFighterHealth(game.TeamB);
                winningTeam = "TeamB";
            }
            return new GameResult { WinningTeam = winningTeam, RemainingHealth = remainingHealth };
        }
    }
}
