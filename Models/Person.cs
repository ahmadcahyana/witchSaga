using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace witchSaga.Models
{
    public class Person
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int AgeofDeath { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int YearofDeath { get; set; }

        public int Killed { get; set; }

        public int YearofBirth { get; set; }

        public Person()
        {

        }

        public Person(int AgeofDeath, int YearofDeath)
        {
            this.AgeofDeath = AgeofDeath;
            this.YearofDeath = YearofDeath;
            YearofBirth = YearofDeath - AgeofDeath;
            Witch witch = new Witch
            {
                Year = YearofBirth
            };
            Killed = witch.Kill();

        }

    }
}
