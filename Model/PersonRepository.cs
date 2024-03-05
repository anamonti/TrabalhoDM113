
public class PersonRepository
{
    public List<Person> PersonList { get; set; }

    public PersonRepository()
    {
        PersonList = new List<Person>();
    }

    public Person AddPerson(Person person)
    {
        PersonList.Add(person);

        return person;
    }

    public Person? DeletePerson(Guid id)
    {
        var personAux = (from pessoa in this.PersonList
                          where pessoa.Id == id
                          select pessoa).SingleOrDefault();

        if (personAux != null) PersonList.Remove(personAux);

        return personAux;
    }

    public List<Person> GetPeople()
    {
        return this.PersonList;
    }

    public Person? GetPerson(Guid id)
    {
        return (from person in PersonList
                    where person.Id == id
                    select person).SingleOrDefault();
    }

    public Person? UpdatePerson(Person person, Guid id)
    {
        var personAux = (from p in this.PersonList
                          where p.Id == id
                          select p).SingleOrDefault();

        if (personAux != null) {
            personAux.CPF = person.CPF;
            personAux.Name = person.Name;
            personAux.Address = person.Address;
        }

        return personAux;
    }
}