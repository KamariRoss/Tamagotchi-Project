using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi_Project.Models;

namespace Tamagotchi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();

        [HttpPost]
        public Pet CreateMenuItem(Pet item)
        {
            // add pets to 
            db.Pets.Add(item);
            db.SaveChanges();
            return item;
        }
        [HttpGet]
        public List<Pet> GetAllPets()
        {
            // query for all the pets
            // sort them by name
            var pets = db.Pets.OrderBy(p => p.Name);
            // return the sorted items  
            return pets.ToList();
        }
        [HttpGet("{id}")]
        public Pet ListAllIds(int id)
        {
            //query for all pets
            // sort them by Id 
            var pets = db.Pets.FirstOrDefault(p => p.Id == id);
            // return the list 
            return pets;
        }
        [HttpPut("{id}/play")]
        public Pet LoveAndAttention(int id)
        {
            // PUT /api/pets/{id}/play, This should find the pet by id,
            var pets = db.Pets.FirstOrDefault(p => p.Id == id);
            // and add 5 to its happiness level and 
            pets.HungerLevel += 5;
            pets.HappinessLevel += 3;
            //add 3 to its hungry level
            db.SaveChanges();
            return pets;

        }
        [HttpPut("{id}/feed")]
        public Pet FeedYourPet(int id)
        {
            // PUT /api/pets/{id}/play, This should find the pet by id,
            var pets = db.Pets.FirstOrDefault(p => p.Id == id);
            // and subtract 5 to its happiness level and 
            pets.HungerLevel -= 5;
            pets.HappinessLevel += 3;
            //add 3 to its hungry level
            db.SaveChanges();
            return pets;
        }
        [HttpPut("{id}/scold")]
        public Pet ScoldYourPet(int id)
        {
            // PUT /api/pets/{id}/play, This should find the pet by id,
            var pets = db.Pets.FirstOrDefault(p => p.Id == id);
            // and substract 5 to its happiness level and 
            pets.HappinessLevel -= 5;
            //add 3 to its hungry level
            db.SaveChanges();
            return pets;
        }
        [HttpDelete("{id}/delete")]
        public Pet DeleteYourPet(int id)
        {
            // PUT /api/pets/{id}/play, This should find the pet by id,
            var pets = db.Pets.FirstOrDefault(p => p.Id == id);
            db.Pets.Remove(pets);
            db.SaveChanges();
            return pets;
        }

    }

}

