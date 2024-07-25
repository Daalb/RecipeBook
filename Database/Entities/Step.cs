using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Step
    {
        [Key]
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = new Recipe();
    }
}
