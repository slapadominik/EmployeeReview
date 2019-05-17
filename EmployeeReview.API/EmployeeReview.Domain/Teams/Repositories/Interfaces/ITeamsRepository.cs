﻿using System.Collections.Generic;
using EmployeeReview.Domain.Common.Persistence.DAO;

namespace EmployeeReview.Domain.Teams.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        IEnumerable<TeamDAO> Get();
    }
}