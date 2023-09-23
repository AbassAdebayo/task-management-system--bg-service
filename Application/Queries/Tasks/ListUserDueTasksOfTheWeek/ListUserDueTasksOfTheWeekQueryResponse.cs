﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Tasks.ListUserDueTasksOfTheWeek
{
    public sealed record ListUserDueTasksOfTheWeekQueryResponse(IList<Domain.Entities.Tasks> tasks)
    {
    }
}
