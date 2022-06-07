﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private static List<Animals> animals = new List<Animals>
            {
                new Animals
                {
                    Id = 1, Name = "słoń",
                    FirstName = "Jan",
                    LastName = "Trąbalski",
                    Place = "Afica"
                },
                new Animals
                {
                    Id = 2, Name = "kaczka",
                    FirstName = "Aleksandra",
                    LastName = "Krzywodziób",
                    Place = "Staw pod Wierzbą"
                }
            };

        //Get

        [HttpGet]
        public async Task<ActionResult<List<Animals>>> Get()
        {
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animals>> Get(int id)
        {
            var animal = animals.Find(x => x.Id == id);
            if (animal == null)
                return BadRequest("Animal not found.");

            return Ok(animal);
        }

        //Post

        [HttpPost]
        public async Task<ActionResult<List<Animals>>> AddAnimal(Animals animal)
        {
            animals.Add(animal);

            return Ok(animals);
        }

        //Put

        [HttpPut]
        public async Task<ActionResult<List<Animals>>> UpdateAnimal(Animals request)
        {
            var animal = animals.Find(x => x.Id == request.Id);
            if (animal == null)
                return BadRequest("Animal not found.");

            animal.Name = request.Name;
            animal.FirstName = request.FirstName;
            animal.LastName = request.LastName;
            animal.Place = request.Place;

            return Ok(animals);
        }

        //Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Animals>>> Delete(int id)
        {
            var animal = animals.Find(x => x.Id == id);
            if (animal == null)
                return BadRequest("Animal not found.");

            animals.Remove(animal);

            return Ok(animals);
        }

    }
}