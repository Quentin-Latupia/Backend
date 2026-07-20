using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUtilisateurRepo
    {
        List<planningDTO> planingTerrain(int idTerrain);
    }
}
