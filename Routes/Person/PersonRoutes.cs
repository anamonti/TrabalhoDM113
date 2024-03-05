public static class PersonRoutes {
    public static RouteGroupBuilder MapPersonApi(this RouteGroupBuilder group)
    {
        var personRepository = new PersonRepository();

        group.MapGet("/", () => {
            return personRepository.GetPeople();
        });

        group.MapGet("/{id}", (Guid id) => {
            var person = personRepository.GetPerson(id);
            
            if (person != null) {
                return Results.Ok(person);
            } else {
                return Results.NotFound("Person not found.");
            } 
        });

        group.MapPost("/", (Person person) => {
            return personRepository.AddPerson(person);
        });

        group.MapDelete("/{id}", (Guid id) => {
            var personDeleted = personRepository.DeletePerson(id);
            
            if (personDeleted != null) {
                return Results.Ok(personDeleted);
            } else {
                return Results.NotFound("Person not found.");
            }       
        });

        group.MapPut("/{id}", (Person person, Guid id) => {
            var personUpdated = personRepository.UpdatePerson(person, id);

            if (personUpdated != null) {
                return Results.Ok(personUpdated);
            } else {
                return Results.NotFound("Person not found.");
            }
        });

        return group;
    }
}