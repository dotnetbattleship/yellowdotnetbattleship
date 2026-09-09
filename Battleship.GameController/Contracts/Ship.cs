using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Battleship.GameController.Contracts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ship.
    /// </summary>
    public class Ship
    {
        private bool isPlaced;
        private int health;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        public Ship(string Name, int Size)
        {
            this.Name = Name;
            this.Size = Size;
            this.isPlaced = false;
            Positions = new List<Position>();
            health = Size;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        public List<Position> Positions { get; set; }

        /// <summary>
        /// The color of the ship
        /// </summary>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public int Size { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add position.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public void AddPosition(string input)
        {
            if (Positions == null)
            {
                Positions = new List<Position>();
            }

            var letter = (Letters)Enum.Parse(typeof(Letters), input.ToUpper().Substring(0, 1));
            var number = int.Parse(input.Substring(1, 1));
            Positions.Add(new Position { Column = letter, Row = number });
        }

        public bool IsPlaced
        {
            get { return isPlaced; }
            set
            {
                if (value.Equals(isPlaced)) return;
                isPlaced = value;
            }
        }

        public (bool hit, bool destroyed) IsHit(string input)
        {
            var letter = (Letters)Enum.Parse(typeof(Letters), input.ToUpper().Substring(0, 1));
            var number = int.Parse(input.Substring(1, 1));
            var shot = new Position { Column = letter, Row = number };

            if (Positions == null)
            {
                throw new ArgumentNullException("Positions");
            }

            if (shot == null)
            {
                throw new ArgumentNullException("shot");
            }

            foreach (var position in Positions)
            {
                bool destroyed = false;
                if (position.Equals(shot))
                {
                    ///modified to decrement health when hit
                    health--;
                    if (health == 0)
                    {
                        destroyed = true;
                    }
                    return (true, destroyed);
                }
            }

            return (false, false);
        }
        #endregion
    }
}
