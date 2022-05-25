﻿using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Model.Entity.ViewModels;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IFabricanteService : IGenericService<FabricanteViewModel, FabricanteFilter>
    {
    }
}
