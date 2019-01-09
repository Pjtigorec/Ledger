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

        public List<State> States { get; set; }
        public string StateName { get; set; }

        [Required]
        [Display(Name = "Кабинет")]
        public int RoomId { get; set; }

        public List<Room> Rooms { get; set; }
        public string RoomName { get; set; }

        public string Image { get; set; }

        public static Subject ConvertModelToSubject(SubjectModel model)
        {
            Subject subject = new Subject();

            subject.Name = model.Name;
            subject.InventoryNumber = model.InventoryNumber;
            subject.Description = model.Description;
            subject.StateId = model.StateId;
            subject.RoomId = model.RoomId;

            return subject;
        }

        public static SubjectModel ConvertSubjectToModel(Subject subject)
        {
            SubjectModel model = new SubjectModel();

            model.Id = subject.Id;
            model.Name = subject.Name;
            model.InventoryNumber = subject.InventoryNumber;
            model.Description = subject.Description;
            model.StateId = subject.StateId;
            model.RoomId = subject.RoomId;

            return model;
        }
    }
}
