﻿using WorkoutApi.Domain.Models;

namespace WorkoutApi.DTOs
{
    namespace WorkoutApi.Dtos
    {
        public class EquipmentDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public EquipmentDto(Equipment equipment)
            {
                Id = equipment.Id;
                Name = equipment.Name;
                Description = equipment.Description;
            }
        }
    }

}
