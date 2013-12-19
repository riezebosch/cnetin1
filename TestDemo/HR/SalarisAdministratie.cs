using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class SalarisAdministratie
    {
        IPersoneelsAdministratie _pa;
        internal SalarisAdministratie(IPersoneelsAdministratie pa)
        {
            _pa = pa;
        }

        public SalarisAdministratie()
            : this (new PersoneelsAdministratie())
        {
        }

        public bool PasSalarisAan(int medewerkersId, decimal salaris)
        {
            //IPersoneelsAdministratie pa = new PersoneelsAdministratie();
            Medewerker mw = _pa.ZoekMedewerker(medewerkersId);
            
            if (mw != null)
            {
                mw.Salaris = salaris;
                return true;
            }

            return false;
        }
    }
}
