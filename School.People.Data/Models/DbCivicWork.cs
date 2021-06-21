using System;
using School.People.Core.Attributes;

namespace School.People.Data
{
    internal class DbCivicWork : DbOccupation, ICivicWork
    {
        public double TotalHoursWorked { get; set; }
    }
}
