using System;
using School.People.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbPerson : DbEntitySingle, IPerson
    {
        [Required]
        [MinLength(Constants.PersonNameFieldsMinLength)]
        [MaxLength(Constants.PersonSurnameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MinLength(Constants.PersonNameFieldsMinLength)]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(Constants.PersonNameFieldsMinLength)]
        [MaxLength(Constants.PersonSurnameMaxLength)]
        public string MiddleName { get; set; }

        [MaxLength(Constants.PersonNameExtensionMaxLength)]
        public string NameExtension { get; set; }

        [MaxLength(Constants.PersonTitleMaxLength)]
        public string Title { get; set; }

        [DefaultValue(false)]
        public bool IsPersonnel { get; set; }

        [DefaultValue(false)]
        public bool IsStudent { get; set; }

        [DefaultValue(false)]
        public bool IsOther { get; set; }
    }
}
