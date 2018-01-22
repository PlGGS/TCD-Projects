using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    class Room
    {
        public int num;
        public bool hasPit = false;
        public bool hasBats = false;
        public bool hasWumpus = false;
        public Room[] neighbors;
        frmWumpus frmWumpus;

        public Room(frmWumpus frm)
        {
            neighbors = new Room[3];
            frmWumpus = frm;
            Reset();
        }

        /// <summary>
        /// Sets flags back to false
        /// </summary>
        public void Reset()
        {
            hasBats = false;
            hasPit = false;
            hasWumpus = false;
        }

        public void Print()
        {
            frmWumpus.WriteLine("You are in room  " + num);
            frmWumpus.WriteLine("There are passages to rooms " +
                neighbors[0].num + ", " +
                neighbors[1].num + ", and " +
                neighbors[2].num
                );

            if (HasDraft())
            {
                frmWumpus.WriteLine("~You can feel a draft~");
            }
            else if (HasDraft())
            {
                frmWumpus.WriteLine("*Squeak* *Squeak* There must be bats nearby.");
            }
            else if (CanSmellWumpus())
            {
                frmWumpus.WriteLine("I SMELL A WUMPUS!");
            }

        }

        /// <summary>
        /// Returns true if this room is adjacent to one with the Wumpus
        /// </summary>
        /// <returns></returns>
        public bool CanSmellWumpus()
        {
            foreach (Room neighbor in neighbors)
            {
                if (neighbor.hasWumpus)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if this room is adjacent to one with a pit
        /// </summary>
        /// <returns></returns>
        public bool HasDraft()
        {
            foreach (Room neighbor in neighbors)
            {
                if (neighbor.hasPit)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if this room is adjacent to one with a bats
        /// </summary>
        /// <returns></returns>
        public bool HearsBats()
        {
            foreach (Room neighbor in neighbors)
            {
                if (neighbor.hasBats)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
