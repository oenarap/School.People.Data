using System;
using School.People.Core;
using System.ComponentModel;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbWork : DbOccupation, IWork
    {
        public decimal MonthlySalary { get; set; }

        [MaxLength(Constants.SalaryGradeAndStepIncrementMaxLength)]
        public string SalaryGradeAndStepIncrement { get; set; }

        [MaxLength(Constants.StatusOfAppointmentMaxLength)]
        public string StatusOfAppointment { get; set; }

        [DefaultValue(false)]
        public bool IsGovernmentService { get; set; }
    }
}
