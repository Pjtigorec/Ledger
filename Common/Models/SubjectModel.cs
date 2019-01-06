using Common.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Номер")]
        public string InventoryNumber { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Состояние")]
        public int StateId { get; set; }

        public IEnumerable<State> States { get; set; }

        [Required]
        [Display(Name = "Кабинет")]
        public Room Room { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
