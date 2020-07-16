using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookbookApplication.BL.Models
{

    public class RecipeModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ICollection<RecipeModel> Children { get; set; } = new List<RecipeModel>();
    }
}