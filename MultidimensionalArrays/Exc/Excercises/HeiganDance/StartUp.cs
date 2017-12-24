/// <summary>
/// All in one file due to solution submission restrictions
/// </summary>
namespace HeiganDance
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Cell[][] lair = new Cell[15][];
            for (int i = 0; i < lair.Length; i++)
            {
                lair[i] = new Cell[15];

                for (int j = 0; j < lair[i].Length; j++)
                {
                    lair[i][j] = new Cell()
                    {
                        Row = i,
                        Column = j
                    };
                }
            }

            int playerRow = 7;
            int playerColumn = 7;

            double hitPointsHeigan = 3000000;
            int hitPointsPLayer = 18500;

            double playerDamagePerTurn = double.Parse(Console.ReadLine());
            bool playerAffectedByCloudFromPreviousRound = false;
            bool playerIsAlive = true;
            bool HeiganIsAlive = true;
            SpellType lastSpellDamagingThePlayer = SpellType.None;

            while (playerIsAlive && HeiganIsAlive)
            {
                string[] roundInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                SpellType spellType = (SpellType)Enum.Parse(typeof(SpellType), roundInput[0]);
                int spellRow = int.Parse(roundInput[1]);
                int spellColumn = int.Parse(roundInput[2]);

                // It is stated that both Heigan and the player may die at the same turn, so the player must deal damage first (even before Plague Cloud effects)
                hitPointsHeigan -= playerDamagePerTurn;

                if (hitPointsHeigan <= 0)
                {
                    HeiganIsAlive = false;
                }

                // Deal cloud damage if any
                if (playerAffectedByCloudFromPreviousRound)
                {
                    hitPointsPLayer -= 3500;
                    lastSpellDamagingThePlayer = SpellType.Cloud;
                    // Reset Plague Cloud effect
                    playerAffectedByCloudFromPreviousRound = false;
                }

                if (hitPointsPLayer <= 0)
                {
                    playerIsAlive = false;
                    break;
                }

                if (HeiganIsAlive)
                {
                    AffectCells(lair, spellType, spellRow, spellColumn);
                }

                // Try move player if he is affected by a spell
                (playerRow, playerColumn) = TryMovePlayer(playerRow, playerColumn, lair);

                // Deal damage to player if he has not escaped the spell
                if (lair[playerRow][playerColumn].AffectedBy == SpellType.Cloud)
                {
                    playerAffectedByCloudFromPreviousRound = true;
                    hitPointsPLayer -= 3500;
                    lastSpellDamagingThePlayer = SpellType.Cloud;
                }
                else if (lair[playerRow][playerColumn].AffectedBy == SpellType.Eruption)
                {
                    hitPointsPLayer -= 6000;
                    lastSpellDamagingThePlayer = SpellType.Eruption;
                }

                if (hitPointsPLayer <= 0)
                {
                    playerIsAlive = false;
                    break;
                }

                ClearSpellEffectsFromCells(lair);
            }

            Console.WriteLine(HeiganIsAlive ? ("Heigan: " + String.Format("{0:0.00}", hitPointsHeigan)) : "Heigan: Defeated!");
            Console.WriteLine(playerIsAlive ? ("Player: " + hitPointsPLayer) : "Player: Killed by " + (lastSpellDamagingThePlayer==SpellType.Cloud ? "Plague Cloud" : lastSpellDamagingThePlayer.ToString()) );
            Console.WriteLine($"Final position: {playerRow}, {playerColumn} ");
        }

        private static void ClearSpellEffectsFromCells(Cell[][] lair)
        {
            foreach (Cell[] row in lair)
            {
                foreach (Cell cell in row)
                {
                    cell.AffectedBy = SpellType.None;
                }
            }
        }

        private static (int newPlayerRow, int newPlayerColumn) TryMovePlayer(int playerRow, int playerColumn, Cell[][] lair)
        {
            if (lair[playerRow][playerColumn].AffectedBy != SpellType.None)
            {
                // Tries to move up
                if (CellIsPresentAndFree(playerRow - 1, playerColumn, lair))
                {
                    playerRow--;
                }
                // Tries to move right
                else if (CellIsPresentAndFree(playerRow, playerColumn + 1, lair))
                {
                    playerColumn++;
                }
                // Tries to move down
                else if (CellIsPresentAndFree(playerRow + 1, playerColumn, lair))
                {
                    playerRow++;
                }
                // Tries to move left
                else if (CellIsPresentAndFree(playerRow, playerColumn - 1, lair))
                {
                    playerColumn--;
                }
            }

            return (playerRow, playerColumn);
        }

        private static bool CellIsPresentAndFree(int row, int column, Cell[][] lair)
        {
            if (row >= 0 && row < lair.Length && column >= 0 && column < lair[row].Length)
            {
                if (lair[row][column].AffectedBy == SpellType.None)
                {
                    return true;
                }

            }

            return false;
        }

        private static void AffectCells(Cell[][] lair, SpellType spellType, int spellRow, int spellColumn)
        {
            foreach (Cell[] row in lair)
            {
                foreach (Cell cell in row)
                {
                    if (cell.Row >= spellRow - 1 && cell.Row <= spellRow + 1 && cell.Column >= spellColumn - 1 && cell.Column <= spellColumn + 1)
                    {
                        cell.AffectedBy = spellType;
                    }
                }
            }
        }
    }

    internal class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public SpellType AffectedBy { get; set; }

        public Cell()
        {
            this.AffectedBy = SpellType.None;
        }
    }

    internal enum SpellType
    {
        None,
        Cloud,
        Eruption
    }
}