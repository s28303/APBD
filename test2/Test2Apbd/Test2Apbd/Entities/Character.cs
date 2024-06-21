﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2Apbd.Entities
{
    [Table("Characters")]
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(120)]
        public string LastName { get; set; } = string.Empty;
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }


        public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();

        public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    }
}
