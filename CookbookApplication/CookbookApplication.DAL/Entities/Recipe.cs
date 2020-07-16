using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookApplication.DAL.Entities
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public Guid? ParentId { get; set; }
        public virtual Recipe Parent { get; set; }
        public virtual ICollection<Recipe> Children { get; set; } = new List<Recipe>();
    }
}