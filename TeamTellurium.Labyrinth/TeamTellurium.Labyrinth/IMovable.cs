using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTellurium.Labyrinth
{
    interface IMovable
    {
        void MoveAtDirection(Direction direction);
    }
}
