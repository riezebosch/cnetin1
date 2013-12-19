using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class PersoneelsAdministratie : HR.IPersoneelsAdministratie
    {
        public Medewerker ZoekMedewerker(int medewerkersId)
        {
            // Hier staat database toegang
            System.Threading.Thread.Sleep(5000);
            return new Medewerker { Id = medewerkersId, Naam = "Manuel" };
        }
    }
}
