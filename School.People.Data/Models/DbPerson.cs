using System;
using School.People.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbPerson : DbEntitySingle, IPerson
    {
        [Required]
        [MinLength(Lengths.PersonNameFieldsMinLength)]
        [MaxLength(Lengths.PersonSurnameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MinLength(Lengths.PersonNameFieldsMinLength)]
        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(Lengths.PersonNameFieldsMinLength)]
        [MaxLength(Lengths.PersonSurnameMaxLength)]
        public string MiddleName { get; set; }

        [MaxLength(Lengths.PersonNameExtensionMaxLength)]
        public string NameExtension { get; set; }

        [MaxLength(Lengths.PersonTitleMaxLength)]
        public string Title { get; set; }

        [DefaultValue(false)]
        public bool IsPersonnel { get; set; }

        [DefaultValue(false)]
        public bool IsStudent { get; set; }

        [DefaultValue(false)]
        public bool IsOther { get; set; }
    }
}
